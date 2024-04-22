using Accessors.DBModels;
using Managers.Models;

namespace Managers.Helpers;

public class AccountHelper
{
    public static Account AccountDataModelToAccount(AccountDataModel account)
    {
        return new Account
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

    public static AccountDataModel AccountToAccountDataModel(Account account)
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