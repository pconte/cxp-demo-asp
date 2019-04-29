Using ASP.NET Core as the server, serving a Vue UI.

I didn't want to merely duplicate the toy server I built in node for the framework-focused demo,
which did not persist the data in a database, but merely served a couple JavaScript arrays as mocks.
Instead, I attempted to use an in-memory SQLite database along with the Entity Framework to add
persistence to a relational database.

I dug around the internet learning a couple different ways to seed the database and how the DBContext works.
I got stuck trying to use the many-to-many relationship between Article and Tag to deliver a collection of
related tags for each article in the search response, so the results filtering does not work, and the suggestions
API endpoint does not return any data as I am not persisting each search query.