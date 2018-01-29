﻿/*
Government Usage Rights Notice:  The U.S. Government retains unlimited, royalty-free usage rights to this software, but not ownership, as provided by Federal law.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

•	Redistributions of source code must retain the above Government Usage Rights Notice, this list of conditions and the following disclaimer.

•	Redistributions in binary form must reproduce the above Government Usage Rights Notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

•	Neither the names of the National Library of Medicine, the National Institutes of Health, nor the names of any of the software developers may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE U.S. GOVERNMENT AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITEDTO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE U.S. GOVERNMENT
OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using Imppoa.HtmlZoning.Dom;

namespace Imppoa.HtmlRendering
{
    /// <summary>
    /// MsHtml document
    /// </summary>
    public class MsHtmlDocument : HtmlDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MsHtmlDocument" /> class
        /// </summary>
        /// <param name="root">The root element</param>
        /// <param name="info">The Html Document information</param>
        /// <param name="defaultStyleLookup">The default style lookup</param>
        /// <param name="displayHtml">The display HTML</param>
        public MsHtmlDocument(MsHtmlElement root, HtmlDocumentInfo info, DefaultStyleLookup defaultStyleLookup, string displayHtml)
            : base(root, info, defaultStyleLookup)
        {
            this.DisplayHtml = displayHtml;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MsHtmlDocument" /> class
        /// </summary>
        /// <param name="root">The root element</param>
        /// <param name="info">The Html Document information</param>
        /// <param name="defaultStyleLookup">The default style lookup</param>
        public MsHtmlDocument(MsHtmlElement root, HtmlDocumentInfo info, DefaultStyleLookup defaultStyleLookup)
            : base(root, info, defaultStyleLookup)
        {
        }
    }
}