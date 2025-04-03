# CasualDev.ColorLib
A C# Library that adds a data type for storing colour values.

## Installation
This library can be installed on Visual Studio 2022 or in the terminal, with the following command.
###### If you experience any errors, please make sure that you are executing the command in the root of your repository.

```powershell
dotnet add package CasualDev.ColorLib --version 1.1.2
```

Other methods of installation can be found on [NuGet](https://www.nuget.org/packages/CasualDev.ColorLib/).

## Description & Syntax
CasualDev.ColorLib adds a hex struct that can be referenced like any regular data type. This contains:
- hex.Blend() which blends two colors together, returning a mix of these colors as a hex data type.
- hex.Lighten() which lightens a color, returning a lighter color as a hex data type.
- hex.Darken() which darkens a color, returning a darker color as a hex data type.
- hex.SetTextColor() which sets the color of the following text.
- hex.SetBackgroundColor() which sets the background color of the following text.
- hex.Reset() which resets all color setting configurations and resets the text back to plain white.
- hex.ToString() which returns the hex in string representation for display of hexadecimal codes.

The syntax for declaring types of hex and using them are as follows:
```cs
using CasualDev.ColorLib;

namespace TestApplication
{
  class Program
  {
    hex red = 0xFF0000;
    red.SetTextColor();
    Console.WriteLine($"The color of this text is {red.ToString()}!");

    hex.Reset();
  }
}
```

## Version & Patch Notes
Version 1.1.3 is a "patch" type update. 

This update fixes the following:
- Corrected licensing and licensing files
- hex is no longer "internal" and is now "public"

This update changes/adds the following on the GitHub:
- LICENSE File
- .gitignore File
- Project solution
- Unit tests

This update changes the following in the files:
- "Class1.cs" to "hexStruct.cs"

## Licensing
This project is licensed under the Mozilla Public License 2.0.
See the full license at: https://opensource.org/licenses/MPL-2.0

Works using this library are not required to provide credit as long as the source code of this project is not modified. If you modify or redistribute this project, you must comply with the terms of the MPL-2.0, which include providing attribution and making the modified source code available under the same license.
