# Neumorphism.Base
[![Nuget](https://img.shields.io/nuget/v/Neumorphism.Design.Base.svg)](https://www.nuget.org/packages/Neumorphism.Design.Base)

[![Build and publish packages](https://github.com/fukicycle/neumorphism.design.base/actions/workflows/production.yml/badge.svg)](https://github.com/fukicycle/neumorphism.design.base/actions/workflows/production.yml)

Provides a neumorphism design base for blazor app. It is very easy to apply neumophism design.

## Features
1. Supply neumorphism design base.

## Installing and Getting started
### 1. install package.
`Neumorphism.Base` is available for download and installation as [NuGet packages](https://www.nuget.org/packages/Neumorphism.Design.Base).
```
dotnet add package Neumorphism.Design.Base --version <version>
```

### 2. Create your blazor app.
1. Add using `fukicycle.Blazor.Neumorphism.Design.Base` (`_Imports.razor`)
```diff
@using System.Net.Http
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.JSInterop
@using BlazorApp1
@using BlazorApp1.Shared
+ @using fukicycle.Blazor.Neumorphism.Design.Base
```
1. Add `UseNeumorphism(BaseColor.Parse("#e0e0e0"))` (`Program.cs`)
```csharp
app.UseNeumorphism(BaseColor.Parse("#e0e0e0"));
```
1. Add `Neumorphism` components! (`Index.razor`)
```razor
@page "/"

<PageTitle>Index</PageTitle>

@*Default ShapeType=FLOAT,LightLocation=TOP_LEFT*@
<Neumorphism>
    <h1>Hello, world!</h1>
</Neumorphism>

@*ShapeType=SINK,LightLocation=TOP_LEFT*@
<Neumorphism ShapeType="ShapeType.SINK">
    Welcome to your new app.
</Neumorphism>

@*ShapeType=CONCAVE,LightLocation=TOP_LEFT*@
<Neumorphism ShapeType="ShapeType.CONCAVE">
    <SurveyPrompt Title="How is Blazor working for you?" />
</Neumorphism>

@*apply input tag*@
<Neumorphism>
    <input type="date" />
</Neumorphism>

@*ShapeType=CONVEX,LightLocation=BOTTOM_RIGHT*@
<Neumorphism ShapeType="ShapeType.CONCAVE" LightLocation="LightLocation.BOTTOM_RIGHT">
    <div style="width: 100%; aspect-ratio: 1; display:flex; align-items: center; justify-content:center;">
        <div>Hello!</div>
    </div>
</Neumorphism>

```
![image](https://github.com/fukicycle/neumorphism.design.base/assets/106070646/296843a8-f540-46ce-8084-bcd3983861ee)

## Contributing
Pull requests and stars are always welcome.
Contributions are what make the open source community such an amazing place to be learn, inspire, and create.   
Any contributions you make are greatly appreciated.

1. Fork the Project.
2. Create your Feature Branch(`git checkout -b feature/amazing_feature`).
3. Commit your Changes(`git commit -m 'Add some changes'`).
4. Push to the Branch(`git push origin feature/amazing_feature`).
5. Open a Pull Request.

## Author
- [fukicycle](https://github.com/fukicycle)

## License
MIT. Click [here](./LICENSE) for details.
