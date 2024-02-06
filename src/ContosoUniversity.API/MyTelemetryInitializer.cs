

using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System;

public class MyTelemetryInitializer : ITelemetryInitializer
{
    public void Initialize(ITelemetry telemetry)
    {
        if (string.IsNullOrEmpty(telemetry.Context.Cloud.RoleName))
        {
            // Retrieve Cloud RoleInstance from environment variables
            string roleInstance = Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID");

            // Set Cloud RoleInstance using the environment variable or a custom value
            telemetry.Context.Cloud.RoleInstance = string.IsNullOrEmpty(roleInstance) ? "Custom RoleInstance" : roleInstance;
        }
    }
}
