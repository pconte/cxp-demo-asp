Using ASP.NET Core as the server, serving a Vue UI.

I didn't want to merely duplicate the toy server I built in node for the framework-focused demo,
which did not persist the data in a database, but merely served a couple JavaScript arrays as mocks.
Instead, I attempted to use an in-memory SQLite database along with the Entity Framework to add
persistence to a relational database. I dug around the internet learning a couple different ways to
seed the database and how the DBContext works. I got stuck trying to define the many-to-many relationship
between the Article and Tag models in Entity Framework. So this app runs but there is a lot more work to do.