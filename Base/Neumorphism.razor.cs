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
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? Attributes { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; } = null!;

        protected override void OnParametersSet()
        {
            if (ChildContent is null) throw new ArgumentNullException();
        }
    }
}
