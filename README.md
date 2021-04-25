# MyRecipes
This is the repo for the MyRecipes Api.

Please look at the wish list section for things I wish I could do better. Family emergencies took valuable time from development.

## Clone

Note: The following example is written with windows 10 terminal.

### Initialise Git

```
git init
```

Clone source code.

```
git clone https://github.com/slevin93/MyRecipes.git
```

### Build
Navigate to '/MyRecipes/src/' and run the following dotnet cli command to build the project.

```
dotnet build
```

### Run
Navigate to '/MyRecipes/src/' and run the following dotnet cli command to build the project

```
dotnet run
```

## App Setting

### Secret

# Wish List

## Identity

The current authentication / authorisation using a custom made JWT auth. This is not ideal and will be difficult to scale the application and maintain good security going forward. 

### Azure Ad
I was looking to implement an azure ad, this would move the auth provider from myself to azure. While there has been issues recently with Azure AD going offline, it does provide a solid foundation for maintaining a solid user management system. Being able to set permissions and access via the azure as ui rather than in code with my current solution (Which does not currently suppose access and roles).

### Microsoft Identity Framework


### Identity Server
Identity server along with Microsoft Identity would be my go to. While Identity Server would provide some upfront cost to development time, in the long term it would simply need updating when new updates are available. Identity Server provides features to improve security such as using reference tokens, apply scopes and resources. 

Microsoft Identity would be perfect to managing user credentials and third party providers such as Facebook, Google, Microsoft, Twitter. The framework also provides all the functionality that goes with a user management system such as: Login, Logout, Register, Forgotten Password, Reset Password. 

## Caching
Currently there is no caching in the api. This is not ideal considering there are items which can be cached such as Ingredients and popular recipes. For this project, I would use MemoryCache. However, at scale I would look at distributed cache solutions such as implementing IDistributedCache or using a pre-existing provider like redis.

## Integrated Unit Test

## Api Response
Ideally I would wrap all api responses in a parent model. This would provide a standard unified response model. It will also provide the flexibility to add additional metadata where needed. 

```
{
  statusCode: 200,
  hasError: false,
  data: {
    userId: 1,
    userName: "JohnDoe"
  },
  locations: [
    {
      get: "api/v1/users/1"
    }
  ]
}
```

## Error Handling Service
Currently there is no error handling in the application, currently we just return null and throw a bad request. Adding a handling service would provide better control over how the error is thrown. Different status codes can be returned with a user friendly message if an error was to be thrown.

## Logging
Currently there is no logging, ideally Serilog would be implemented to provide the logging. The benefit of Serilog is their use of Sinks, this means logs can be written to different sources. Examples being: Database Table, File, Console. 


