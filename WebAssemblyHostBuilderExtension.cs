using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static fukicycle.Blazor.Neumorphism.Design.Base.Neumorphism;

namespace fukicycle.Blazor.Neumorphism.Design.Base
{
    public static class WebAssemblyHostBuilderExtension
    {
        public static WebAssemblyHostBuilder UseNeumorphism(this WebAssemblyHostBuilder webAssemblyHostBuilder, BaseColor baseColor)
        {
            ColorSetting.BaseColor = baseColor;
            return webAssemblyHostBuilder;
        }
    }
}
