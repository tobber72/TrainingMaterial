using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using CarRental.Business.Entities;
using CarRental.Common;
using Core.Common.Contracts;
using Core.Common.Core;
using Core.Common.ServiceModel;

namespace CarRental.Business.Managers
{
    public class ManagerBase
    {
        public ManagerBase()
        {
            if (HeaderContext<string>.Current != null)
            {
                _LoginName = HeaderContext<string>.Current.Value;
                if (_LoginName.IndexOf(@"\") > -1) _LoginName = string.Empty;
            }

            if (ObjectBase.Container != null)
                ObjectBase.Container.SatisfyImportsOnce(this);

            if (!string.IsNullOrWhiteSpace(_LoginName))
                _AuthorizationAccount = LoadAuthorizationValidationAccount(_LoginName);
        }

        protected virtual Account LoadAuthorizationValidationAccount(string loginName) 
        {
            return null;
        }

        Account _AuthorizationAccount = null;
        string _LoginName = string.Empty;

        protected void ValidateAuthorization(IAccountOwnedEntity entity)
        {
            if (!Thread.CurrentPrincipal.IsInRole(Security.CarRentalAdminRole))
            {
                if (_LoginName == string.Empty || entity.OwnerAccountId != _AuthorizationAccount.AccountId)
                    throw new AuthorizationValidationException("Attempt to access a secure record with improper user authorization validation.");
            }
        }
        
        protected T ExecuteFaultHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (AuthorizationValidationException ex)
            {
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        protected void ExecuteFaultHandledOperation(Action codetoExecute)
        {
            try
            {
                codetoExecute.Invoke();
            }
            catch (AuthorizationValidationException ex)
            {
                throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
