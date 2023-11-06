# Neumorphism.Base
[![Nuget](https://img.shields.io/nuget/v/Neumorphism.Design.Base.svg)](https://www.nuget.org/packages/Neumorphism.Design.Base)

[![Build and publish packages](https://github.com/fukicycle/neumorphism.design.base/actions/workflows/production.yml/badge.svg)](https://github.com/fukicycle/neumorphism.design.base/actions/workflows/production.yml)

Provides a neumorphism design base for blazor app. It is very easy to apply neumophism design.

## Features
1. Supply neumorphism design base.

## Installing and Getting started
### 1. install package.
`Neumorphism.Design.Base` is available for download and installation as [NuGet packages](https://www.nuget.org/packages/Neumorphism.Design.Base).
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
1. Add `UseNeumorphism(BaseColor.Parse("#CDD6EE"))` (`Program.cs`)
```csharp
app.UseNeumorphism(BaseColor.Parse("#CDD6EE"));
```
1. Add `Neumorphism` components! (`Index.razor`)
```razor
@page "/"

<PageTitle>Index</PageTitle>

<Neumorphism class="mb-4 mx-4" ShapeType="ShapeType.CONCAVE" BorderRadius="50%">
    <div style="display:flex; aspect-ratio: 1; width:100%; align-items:center;justify-content:center;">
        <h1>Hello, world!</h1>
    </div>
</Neumorphism>
<Neumorphism class="m-4" ShapeType="ShapeType.CONVEX">
    <SurveyPrompt Title="How is Blazor working for you?" />
</Neumorphism>
<Neumorphism class="m-4">
    <select>
        <option>I like blazor.</option>
        <option>I don't like blazor.</option>
    </select>
</Neumorphism>
<Neumorphism class="m-4">
    <button>OK</button>
</Neumorphism>
<Neumorphism class="m-4" ShapeType="ShapeType.SINK">
    <input type="text" />
</Neumorphism>
<Neumorphism class="m-4" ShapeType="ShapeType.SINK">
    <input type="date" />
</Neumorphism>
```

**Please note that you have to set same color to root element. (`<body/>`)**

![image](https://github.com/fukicycle/neumorphism.design.base/assets/106070646/2d3c6cce-8031-48b0-9a40-63f8d321494e)

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
