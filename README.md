Tasks:

•	Create simple ASP.NET MVC application;

•	Create and Register elements from figure IoC_task.png using Castle.Windsor container;

•	Dependencies should be resolved using DependencyResolver and constructor injection approach;

•	Don’t delete DependencyResolver from the project but configure MVC application to ControllerFactory instead of DependencyResolver;

•	Inject UserService to BaseController using property injection;

•	Integrate container with Castle.Windsor-NLog;

•	Extend the repositories to supporting SQL database via ORM;

•	Add support “transaction per web request” feature. A custom ASP.NET MVC ActionInvoker should be used for this purpose.
