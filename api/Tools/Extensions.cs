﻿using Microsoft.AspNetCore.Mvc;

namespace App.Api.Extensions
{
    public static class Extensions
    {
        public static string BaseURL(this ControllerBase controller)
        {
            if (controller.Request != null)
            {
                return $"{controller.Request.Scheme}://{controller.Request.Host}/";
            }

            return "http://localhost:8888/";
        }

        public static bool IsNotEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}