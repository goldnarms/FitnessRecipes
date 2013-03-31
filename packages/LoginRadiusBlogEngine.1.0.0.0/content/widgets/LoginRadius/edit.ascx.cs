using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Code.Controls;




// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The edit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Widgets.Twitter
{
    using System;
    using System.Web;

    using App_Code.Controls;
    using BlogEngine.Core;

    /// <summary>
    /// The edit.
    /// </summary>
    public partial class widgets_LoginRadius_edit : WidgetEditBase
    {
        /// <summary>
        /// Saves this the basic widget settings such as the Title.
        /// </summary>
        public override void Save()
        {
            var settings = this.GetSettings();
            settings["key"] = this.txtKey.Text;
            settings["secret"] = this.txtsecret.Text;
            this.SaveSettings(settings);
        }




        #region Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs"/> object that contains the event data.
        /// </param>
        protected override void OnInit(EventArgs e)
        {
            var settings = this.GetSettings();
            this.txtKey.Text = settings["key"];
            this.txtsecret.Text = settings["secret"];

            base.OnInit(e);
        }

        #endregion
    }
}