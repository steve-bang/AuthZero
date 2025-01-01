// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using AuthZero.AccountService.Infrastructure;
using MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();



builder.AddSqlServerDbContext<AccountServiceContext>("Account");

builder.Services.AddOpenTelemetry()
		.WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));


var app = builder.Build();

app.Run();
