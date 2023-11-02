using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fukicycle.Blazor.Neumorphism.Design.Base
{
    public static class WebApplicationExtension
    {
        public static IApplicationBuilder UseNeumorphism(this IApplicationBuilder builder, BaseColor baseColor)
        {
            ColorSetting.BaseColor = baseColor;
            return builder;
        }
    }
}
