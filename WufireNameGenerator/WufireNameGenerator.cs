/*
The MIT License (MIT)

Copyright (c) 2016 Andrew Wu

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

Original base-set of names provided by reddit user /u/TPangolin

RedirectionHelper.cs was taken from the Moledozer mod found here:
  * https://github.com/fadster/Moledozer/blob/master/Moledozer/RedirectionHelper.cs

*/

using ICities;
using System;
using ColossalFramework.IO;
namespace WufireNameGenerator
{
  public class WufireNameGenerator : IUserMod
  {
    public static string CommercialNameFile {
      get {
        return DataLocation.modsPath + "/WufireNameGenerator/CommercialNames.json";
      }
    }

    public static string OfficeNameFile {
      get {
        return DataLocation.modsPath + "/WufireNameGenerator/OfficeNames.json";
      }
    }

    public static string IndustryNameFile {
      get {
        return DataLocation.modsPath + "/WufireNameGenerator/IndustryNames.json";
      }
    }

    public static string ResidentialNameFile {
      get {
        return DataLocation.modsPath + "/WufireNameGenerator/ResidentialNames.json";
      }
    }

    public string Description
    {
      get
      {
        return "Add your own building names! Rename residential, industrial, office and commercial buildings in the mods folder.";
      }
    }

    public string Name
    {
      get
      {
        return "Custom Building Name Generator";
      }
    }
  }
}
