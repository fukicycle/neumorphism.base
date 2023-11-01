using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public RenderFragment ChildContent
        {
            get => _childContent;
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(value));
                if (_childContent != value)
                {
                    _childContent = value;
                }
            }
        }

        [Parameter]
        public ShapeType ShapeType
        {
            get => _shapeType;
            set
            {
                if (value != _shapeType)
                {
                    _shapeType = value;
                    OnSettingChanged();
                }
            }
        }

        [Parameter]
        public LightLocation LightLocation
        {
            get => _lightLocation;
            set
            {
                if (value != _lightLocation)
                {
                    _lightLocation = value;
                    OnSettingChanged();
                }
            }
        }

        [Parameter]
        public BaseColor Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnSettingChanged();
                }
            }
        }


        private RenderFragment _childContent = null!;
        private ShapeType _shapeType = ShapeType.FLOAT;
        private LightLocation _lightLocation = LightLocation.TOP_LEFT;
        private BaseColor _color = new BaseColor(224, 224, 224);

        private string _style = "";

        private static int offset = 9;
        private static int blur = offset * 2;

        protected override void OnInitialized()
        {
            OnSettingChanged();
        }


        private void OnSettingChanged()
        {
            string baseColor = Color.GetBaseColor();
            string darkColor = Color.GetDarkColor();
            string lightColor = Color.GetLightColor();
            _style = "";
            if (ShapeType == ShapeType.SINK)
            {
                _style += $"background: {baseColor};";
                switch (LightLocation)
                {
                    case LightLocation.TOP_LEFT:
                        _style += $"box-shadow: inset {offset}px {offset}px {blur}px {darkColor}, inset -{offset}px -{offset}px {blur}px {lightColor};";
                        break;
                    case LightLocation.TOP_RIGHT:
                        _style += $"box-shadow: inset -{offset}px {offset}px {blur}px {darkColor}, inset {offset}px -{offset}px {blur}px {lightColor};";
                        break;
                    case LightLocation.BOTTOM_LEFT:
                        _style += $"box-shadow: inset {offset}px -{offset}px {blur}px {darkColor}, inset -{offset}px {offset}px {blur}px {lightColor};";
                        break;
                    case LightLocation.BOTTOM_RIGHT:
                        _style += $"box-shadow: inset -{offset}px -{offset}px {blur}px {darkColor}, inset {offset}px {offset}px {blur}px {lightColor};";
                        break;
                }
            }
            else
            {

                switch (ShapeType)
                {
                    case ShapeType.FLOAT:
                        _style += $"background: {baseColor};";
                        break;
                    case ShapeType.CONVEX:
                        _style += $"background: linear-gradient(145deg, {darkColor}, {lightColor});";
                        break;
                    case ShapeType.CONCAVE:
                        _style += $"background: linear-gradient(145deg, {lightColor}, {darkColor});";
                        break;
                }
                switch (LightLocation)
                {
                    case LightLocation.TOP_LEFT:
                        _style += $"box-shadow: {offset}px {offset}px {blur}px {darkColor}, -{offset}px -{offset}px {blur}px {lightColor};";
                        break;
                    case LightLocation.TOP_RIGHT:
                        _style += $"box-shadow: -{offset}px {offset}px {blur}px {darkColor}, {offset}px -{offset}px {blur}px {lightColor};";
                        break;
                    case LightLocation.BOTTOM_LEFT:
                        _style += $"box-shadow: {offset}px -{offset}px {blur}px {darkColor}, -{offset}px {offset}px {blur}px {lightColor};";
                        break;
                    case LightLocation.BOTTOM_RIGHT:
                        _style += $"box-shadow: -{offset}px -{offset}px {blur}px {darkColor}, {offset}px {offset}px {blur}px {lightColor};";
                        break;
                }
            }
            StateHasChanged();
        }

        public class BaseColor
        {
            public BaseColor(byte red, byte green, byte blue)
            {
                Red = red;
                Green = green;
                Blue = blue;
            }
            public byte Red { get; }
            public byte Green { get; }
            public byte Blue { get; }

            public string GetBaseColor()
            {
                return "#" + Red.ToString("X2") + Green.ToString("X2") + Blue.ToString("X2");
            }

            public string GetLightColor()
            {
                Color color = System.Drawing.Color.FromArgb(Red, Green, Blue);
                HslColor hsl = HslColor.FromRgb(color);
                hsl.L = hsl.L + 0.1f;
                if (hsl.L > 1) hsl.L = 1;
                Color lightColor = HslColor.ToRgb(hsl);
                return "#" + lightColor.R.ToString("X2")
                    + lightColor.G.ToString("X2")
                    + lightColor.B.ToString("X2");

            }

            public string GetDarkColor()
            {
                Color color = System.Drawing.Color.FromArgb(Red, Green, Blue);
                HslColor hsl = HslColor.FromRgb(color);
                hsl.L = hsl.L - 0.1f;
                if (hsl.L < 0) hsl.L = 0;
                Color darkColor = HslColor.ToRgb(hsl);
                return "#" + darkColor.R.ToString("X2")
                    + darkColor.G.ToString("X2")
                    + darkColor.B.ToString("X2");
            }
        }
    }
}
