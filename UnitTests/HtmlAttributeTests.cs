﻿//
// HtmlAttributeTests.cs
//
// Author: Jeffrey Stedfast <jestedfa@microsoft.com>
//
// Copyright (c) 2015-2023 Jeffrey Stedfast <jestedfa@microsoft.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using HtmlKit;

namespace UnitTests {
	[TestFixture]
	public class HtmlAttributeTests
	{
		[Test]
		public void TestArgumentExceptions ()
		{
			Assert.Throws<ArgumentOutOfRangeException> (() => new HtmlAttribute (HtmlAttributeId.Unknown, string.Empty));
			Assert.Throws<ArgumentNullException> (() => new HtmlAttribute (null, string.Empty));
			Assert.Throws<ArgumentException> (() => new HtmlAttribute (string.Empty, string.Empty));
			Assert.Throws<ArgumentException> (() => new HtmlAttribute ("a b c", string.Empty));
		}

		[Test]
		public void TestToHtmlAttributeId ()
		{
			Assert.AreEqual (HtmlAttributeId.Unknown, "".ToHtmlAttributeId (), "string.Empty");
			Assert.AreEqual (HtmlAttributeId.Alt, "alt".ToHtmlAttributeId (), "alt");
			Assert.AreEqual (HtmlAttributeId.Alt, "Alt".ToHtmlAttributeId (), "Alt");
			Assert.AreEqual (HtmlAttributeId.Alt, "aLt".ToHtmlAttributeId (), "aLt");
			Assert.AreEqual (HtmlAttributeId.Alt, "ALT".ToHtmlAttributeId (), "ALT");
			Assert.AreEqual (HtmlAttributeId.Alt, "AlT".ToHtmlAttributeId (), "AlT");

			HtmlAttributeId parsed;
			string name;

			foreach (HtmlAttributeId value in Enum.GetValues (typeof (HtmlAttributeId))) {
				if (value == HtmlAttributeId.Unknown)
					continue;

				name = value.ToAttributeName ().ToUpperInvariant ();
				parsed = name.ToHtmlAttributeId ();

				Assert.AreEqual (value, parsed, "Failed to parse the HtmlAttributeId value for {0}", value);
			}
		}
	}
}
