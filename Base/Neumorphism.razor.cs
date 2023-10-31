using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fukicycle.blazor.neumorphism.components.Base
{
    public partial class Neumorphism
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; } = null!;

        protected override void OnParametersSet()
        {
            if (ChildContent is null) throw new ArgumentNullException();
        }
    }
}
