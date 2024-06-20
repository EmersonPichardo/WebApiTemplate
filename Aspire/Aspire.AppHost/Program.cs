var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql");
var sqlDb = sql.AddDatabase("sqlDb");

builder.AddProject<Projects.Presentation>("presentation")
    .WithReference(sqlDb);

builder.Build().Run();
