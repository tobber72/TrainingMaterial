using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text.RegularExpressions;
using System.Web.Http;
using AttributeRouting.Web.Http;
using CarRental.Web.Core;
using CarRental.Web.Models;

namespace CarRental.Web.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public AccountApiController(ISecurityAdapter securityAdapter)
        {
            _SecurityAdapter = securityAdapter;
        }
        
        ISecurityAdapter _SecurityAdapter;

        [HttpPost]
        [POST("api/account/register/validate1")]
        public HttpResponseMessage ValidateRegistrationStep1(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                List<string> errors = new List<string>();

                List<State> states = GetStates();
                State state = states.Where(item => item.Abbrev.ToUpper() == accountModel.State.ToUpper()).FirstOrDefault();
                if (state == null)
                    errors.Add("Invalid state.");

                Match matchZipCode = Regex.Match(accountModel.ZipCode, @"^\d{5}(?:[-\s]\d{4})?$");
                if (!matchZipCode.Success)
                    errors.Add("Zip code is in an invalid format.");

                if (errors.Count == 0)
                    response = request.CreateResponse(HttpStatusCode.OK);
                else
                    response = request.CreateResponse<string[]>(HttpStatusCode.BadRequest, errors.ToArray());

                return response;
            });
        }

        [HttpPost]
        [POST("api/account/register/validate2")]
        public HttpResponseMessage ValidateRegistrationStep2(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!_SecurityAdapter.UserExists(accountModel.LoginEmail))
                    response = request.CreateResponse(HttpStatusCode.OK);
                else
                    response = request.CreateResponse<string[]>(HttpStatusCode.BadRequest, new List<string>() { "An account is already registered with this email address." }.ToArray());

                return response;
            });
        }

        [HttpPost]
        [POST("api/account/register/validate3")]
        public HttpResponseMessage ValidateRegistrationStep3(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                List<string> errors = new List<string>();

                if (accountModel.CreditCard.Length != 16)
                    errors.Add("Credit card number is in an invalid format.");

                Match matchExpDate = Regex.Match(accountModel.ExpDate, @"(0[1-9]|1[0-2])\/[0-9]{2}", RegexOptions.IgnoreCase);
                if (!matchExpDate.Success)
                    errors.Add("Expiration date is invalid.");

                if (errors.Count == 0)
                    response = request.CreateResponse(HttpStatusCode.OK);
                else
                    response = request.CreateResponse<string[]>(HttpStatusCode.BadRequest, errors.ToArray());

                return response;
            });
        }

        [HttpPost]
        [POST("api/account/register")]
        public HttpResponseMessage CreateAccount(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                // revalidate all steps to ensure this operation is secure against hacks
                if (ValidateRegistrationStep1(request, accountModel).IsSuccessStatusCode &&
                    ValidateRegistrationStep2(request, accountModel).IsSuccessStatusCode &&
                    ValidateRegistrationStep3(request, accountModel).IsSuccessStatusCode)
                {
                    _SecurityAdapter.Register(accountModel.LoginEmail, accountModel.Password,
                        propertyValues: new 
                        {
                            FirstName = accountModel.FirstName,
                            LastName = accountModel.LastName,
                            Address = accountModel.Address,
                            City = accountModel.City,
                            State = accountModel.State,
                            ZipCode = accountModel.ZipCode,
                            CreditCard = accountModel.CreditCard,
                            ExpDate = accountModel.ExpDate.Substring(0,2) + accountModel.ExpDate.Substring(3,2)
                        });
                    _SecurityAdapter.Login(accountModel.LoginEmail, accountModel.Password, false);

                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        
        [HttpPost]
        [POST("api/account/login")]
        public HttpResponseMessage Login(HttpRequestMessage request, [FromBody]AccountLoginModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                bool success = _SecurityAdapter.Login(accountModel.LoginEmail, accountModel.Password, false);
                if (success)
                    response = request.CreateResponse(HttpStatusCode.OK);
                else
                    response = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized login.");

                return response;
            });
        }

        [HttpPost]
        [POST("api/account/changepw")]
        [Authorize]
        public HttpResponseMessage ChangePassword(HttpRequestMessage request, [FromBody]AccountChangePasswordModel passwordModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ValidateAuthorizedUser(passwordModel.LoginEmail);

                bool success = _SecurityAdapter.ChangePassword(passwordModel.LoginEmail, passwordModel.OldPassword, passwordModel.NewPassword);
                if (success)
                    response = request.CreateResponse(HttpStatusCode.OK);
                else
                    response = request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to change password.");

                return response;
            });
        }

        List<State> GetStates()
        {
            return new List<State>()
            {
            	new State() { Name = "Alaska", Abbrev = "AK"},
			    new State() { Name = "American Samoa", Abbrev = "AS"},
			    new State() { Name = "Arizona", Abbrev = "AZ"},
			    new State() { Name = "Arkansas", Abbrev = "AR"},
			    new State() { Name = "California", Abbrev = "CA"},
			    new State() { Name = "Colorado", Abbrev = "CO"},
			    new State() { Name = "Connecticut", Abbrev = "CT"},
			    new State() { Name = "Delaware", Abbrev = "DE"},
			    new State() { Name = "District of Columbia", Abbrev = "DC"},
			    new State() { Name = "Federated States of Micronesia", Abbrev = "FM"},
			    new State() { Name = "Florida", Abbrev = "FL"},
			    new State() { Name = "Georgia", Abbrev = "GA"},
			    new State() { Name = "Guam", Abbrev = "GU"},
			    new State() { Name = "Hawaii", Abbrev = "HI"},
			    new State() { Name = "Idaho", Abbrev = "ID"},
			    new State() { Name = "Illinois", Abbrev = "IL"},
			    new State() { Name = "Indiana", Abbrev = "IN"},
			    new State() { Name = "Iowa", Abbrev = "IA"},
			    new State() { Name = "Kansas", Abbrev = "KS"},
			    new State() { Name = "Kentucky", Abbrev = "KY"},
			    new State() { Name = "Louisiana", Abbrev = "LA"},
			    new State() { Name = "Maine", Abbrev = "ME"},
			    new State() { Name = "Marshall Islands", Abbrev = "MH"},
			    new State() { Name = "Maryland", Abbrev = "MD"},
			    new State() { Name = "Massachusetts", Abbrev = "MA"},
			    new State() { Name = "Michigan", Abbrev = "MI"},
			    new State() { Name = "Minnesota", Abbrev = "MN"},
			    new State() { Name = "Mississippi", Abbrev = "MS"},
			    new State() { Name = "Missouri", Abbrev = "MO"},
			    new State() { Name = "Montana", Abbrev = "MT"},
			    new State() { Name = "Nebraska", Abbrev = "NE"},
			    new State() { Name = "Nevada", Abbrev = "NV"},
			    new State() { Name = "New Hampshire", Abbrev = "NH"},
			    new State() { Name = "New Jersey", Abbrev = "NJ"},
			    new State() { Name = "New Mexico", Abbrev = "NM"},
			    new State() { Name = "New York", Abbrev = "NY"},
			    new State() { Name = "North Carolina", Abbrev = "NC"},
			    new State() { Name = "North Dakota", Abbrev = "ND"},
			    new State() { Name = "Northern Mariana Islands", Abbrev = "MP"},
			    new State() { Name = "Ohio", Abbrev = "OH"},
			    new State() { Name = "Oklahoma", Abbrev = "OK"},
			    new State() { Name = "Oregon", Abbrev = "OR"},
			    new State() { Name = "Palau", Abbrev = "PW"},
			    new State() { Name = "Pennsylvania", Abbrev = "PA"},
			    new State() { Name = "Puerto Rico", Abbrev = "PR"},
			    new State() { Name = "Rhode Island", Abbrev = "RI"},
			    new State() { Name = "South Carolina", Abbrev = "SC"},
			    new State() { Name = "South Dakota", Abbrev = "SD"},
			    new State() { Name = "Tennessee", Abbrev = "TN"},
			    new State() { Name = "Texas", Abbrev = "TX"},
			    new State() { Name = "Utah", Abbrev = "UT"},
			    new State() { Name = "Vermont", Abbrev = "VT"},
			    new State() { Name = "Virgin Islands", Abbrev = "VI"},
			    new State() { Name = "Virginia", Abbrev = "VA"},
			    new State() { Name = "Washington", Abbrev = "WA"},
			    new State() { Name = "West Virginia", Abbrev = "WV"},
			    new State() { Name = "Wisconsin", Abbrev = "WI"},
			    new State() { Name = "Wyoming", Abbrev = "WY"}
            };
        }
    }
}
