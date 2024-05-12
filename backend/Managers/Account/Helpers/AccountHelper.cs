using Accessors.Account.Models;
using Managers.Address;

namespace Managers.Account.Helpers;

public class AccountHelper
{
    public static Models.Account AccountDataModelToAccount(AccountDataModel account)
    {
        return new Models.Account
        (
            account.AccountId,
            account.FirstName,
            account.LastName,
            account.Email,
            account.Password,
            AddressHelper.AddressDataModelToAddress(account.AccountAddress),
            account.IsAdmin
        );
    }

    public static AccountDataModel AccountToAccountDataModel(Models.Account account)
    {
        return new AccountDataModel
        (
            account.AccountId,
            account.FirstName,
            account.LastName,
            account.Email,
            account.Password,
            AddressHelper.AddressToAddressDataModel(account.AccountAddress),
            account.IsAdmin
        );
    }
}