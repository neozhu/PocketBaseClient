# PocketClient-csharp
(WARNING: At the moment this is only a concept. In active development) Basic client in C# for interacting with PocketBase, with a simple ORM to manage Collections and Registries

There is no available release yet. Is only a concept

## Concept
Simple client access to a defined PocketBase application, with simple ORM with cached objects

There will be a code generator to create classes to navigate throw Collections and Registries, and tools to query data. This client will manage cached objects (with policies) to minimize the api calls.

## Usage
The client code for a PocketBase client application will be generated by a code generator that maps all Collections and Registry schemas to code.

### PocketBase Application
- Name: "Example-app"
- Url: "https://example-app.myurl.io"

Ussage in PocketClient
```csharp
var app = new ExampleAppApplication();
```
You could login as Admin
```csharp
var authAdminModel = await app.Auth.Admin.AuthenticateWithPassword("MyAdmin@email.com", "myAdminPwd");
```
or as user
```csharp
var authUserModel = await app.Auth.User.AuthenticateViaEmail("myUser@email.com", "myUserPwd");
```
(of course, login is not mandatory)
The Authorization token will be sent automatically at every query to get data.

### Collections in PocketBase
Example of collections:
- Authors
- Posts:
  - Has a field "Author" related to Authors
- Labels
- PostsLabels:
  - Has a field "Label" related to Labels
  - Has a field "Post" related to Posts
  
### Navigating data in PocketClient
Similar than:
```csharp
var author = post.Author;
var posts = author.Posts;
var labels = post.PostsLabels.Select(pl => pl.Label);
```
### Getting Collections in Client
Similar than:
```charp
var authors = app.Data.Authors;
var Posts = app.Data.Posts;
```

### Operations with an element
Getting an element:
```csharp
var post = await Post.GetById("xxxxxxxx").GetAsync();
// Or
var post = await app.Data.Posts.GetById("xxxxxxxx").GetAsync();
// Or
var post = await app.Data.Crud.GetById<Post>("xxxxxxxx").GetAsync();
```

Creating an element (only creates the object in memory):
```csharp
var author = new Author(mandatoryField1, mandatoryField2);
// Or
var author = Author.Create(mandatoryField1, mandatoryField2);
```

Saving or Updating an element:
```csharp
author.SaveAsync(); // If is a new element without Id, it will be filled from PocketBae after saved
// Or
app.Data.Crud.SaveAsync(author); // If is a new element without Id, it will be filled from PocketBae after saved
```

Deleting an element:
```csharp
author.DeleteAsync(); 
// Or
app.Data.Crud.DeleteAsync(author); 
```

Discarting local changes not saved:
```csharp
author.Discard(); // Discard local changes in the Author element
// Or
app.Data.Crud.Discard(author); // Discard local changes in the Author element

app.Data.Authors.Discard(); // Discard local changes in every element in Authors collection
// Or
app.Data.Crud.Discard<Author>(); // Discard local changes in every element of type Author

app.Data.Crud.Discard(); // Discard all local changes in any element
```

Reloading data from PocketBase:
```csharp
author.ReloadAsync(); // Reloads the Author item

app.Data.Authors.ReloadAsync(); // Reloads all Author collection

myQuery.ReloadAsync(); // Reloads all Query results
```

### Querying
Something like this
```csharp
app.Data.Posts.QueryAll().GetAsync(); // All Posts
app.Data.QueryAll<Post>().GetAsync(); // All Posts
author.Posts.QueryAll().GetAsync(); // All Posts of the author

app.Data.Posts.Query(strQuery).GetAsync(); // Filter Posts
app.Data.Query<Post>(strQuery).GetAsync(); // Filter Posts
author.Posts.Query(strQuery).GetAsync(); // Filter Posts of the author

app.Data.Posts.Query(strQuery).Paged(1, 20).GetAsync(); // Query paged
app.Data.Query<Post>(strQuery).Paged(1, 20).GetAsync(); // Query paged
author.Posts.Query(strQuery).GetAsync(); // Query paged Posts of the author

app.Data.Posts.Query(strQuery).OrderBy(strOrder).Pagged(1,20).GetAsync(); // Ordered and Paged
app.Data.Query<Post>(strQuery).OrderBy(strOrder).Pagged(1,20).GetAsync();
author.Posts.Query(strQuery).OrderBy(strOrder).Pagged(1,20).GetAsync(); // Query ordered and paged Posts of the author
```

### More...
To think about:
- Fetching
- Force reload items (or not) in GetById, Collection list, Query
- Queries and OrderBy in Fluent form
