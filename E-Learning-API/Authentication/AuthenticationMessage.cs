using System;
using Bogus.DataSets;
using E_Learning_API.Models;

namespace E_Learning_API.Authentication;

public class AuthenticationMessage
{ 
    public static AuthenticationResult MailAlreadyExists()
    {
                            
        return failed("Erreur le mail existe deja");

    }

    public static AuthenticationResult CreationFailed()
    {
        return failed("Erreur serveur l'utilisateur n'a pas pu être crée.");
        
    }

    public static AuthenticationResult TokenCreated(string token)
    {
        return new AuthenticationResult()
        {
            Result = true,
            Token = token
        };
    }

    public static AuthenticationResult WrongField()
    {
        return failed("Les champs ont mal été remplis.");
    }

    public static AuthenticationResult WrongPassword()
    {
        return failed("Mauvais mot de passe");
    }

    public static AuthenticationResult NoUserExisting()
    {
        return failed("Aucun utilisateur trouvé avec cet email");

    }

    public static AuthenticationResult failed(string messageError)
    {
        var ClassProperties = typeof(AuthenticationMessage).GetProperties();
        return new AuthenticationResult()
        {
            Result = false,
            Errors = new List<string>()
            {
                messageError

            },

        };
    }

}

