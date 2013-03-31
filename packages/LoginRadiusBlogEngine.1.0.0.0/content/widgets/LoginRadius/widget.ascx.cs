using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Widgets.BlogRoll
{
    using App_Code.Controls;
    using System.Web.Security;
    using BlogEngine.Core;
    using LoginRadiusDataModal.LoginRadiusDataObject.Objects;

    public partial class widgets_LoginRadius_widget : WidgetBase
    {


        public string Apikey = "";


        public override bool IsEditable
        {
            get
            {
                return true;
            }
        }

        public override string Name
        {
            get
            {
                return "Loginradius";
            }
        }


        public override void LoadWidget()
        {
            PopupVisiblity(false);


            if (Security.IsAuthenticated)
            {
                frmloginradius.Visible = false;

                var roles = Roles.GetRolesForUser();

                if (!roles.Contains(BlogConfig.AdministratorRole))
                {
                    this.Visible = false;
                }
            }
            else
            {
                var settings = this.GetSettings();

                if (settings.ContainsKey("key") && settings.ContainsKey("secret"))
                {
                    //login radius
                    Apikey = settings["key"];

                    LoginRadiusSDKv2.LoginRadius loginradius = new LoginRadiusSDKv2.LoginRadius(settings["secret"]);

                    if (loginradius.IsAuthenticated)
                    {
                        var userprofile = loginradius.GetBasicUserProfile();

                        if (Membership.GetUser(userprofile.ID) != null)
                        {
                            var pwd = Membership.Provider.ResetPassword(userprofile.ID, string.Empty);
                            Security.AuthenticateUser(userprofile.ID, pwd, false);
                            FormsAuthentication.SetAuthCookie(userprofile.ID, false /* createPersistentCookie */);
                        }
                        else
                        {
                            if (userprofile.Email != null)
                            {
                                LoginRadiusLogin(userprofile);
                            }
                            else
                            {
                                hdID.Value = userprofile.ID;
                                hdBirthDate.Value = userprofile.BirthDate ?? "";
                                hdFirstName.Value = userprofile.FirstName ?? "";
                                hdLastName.Value = userprofile.LastName ?? "";
                                hdMiddleName.Value = userprofile.MiddleName ?? "";
                                hdProfileName.Value = userprofile.ProfileName ?? "";

                                PopupVisiblity(true);
                            }
                        }
                    }
                }
            }



        }


        protected void btn_submitemail_click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {


                if (!string.IsNullOrEmpty(txt_email.Text))
                {
                    var userprofile = new BasicUserLoginRadiusUserProfile();


                    userprofile.ID = hdID.Value;
                    userprofile.BirthDate = hdBirthDate.Value;
                    userprofile.Email = new List<LoginRadiusEmail>();
                    userprofile.Email.Add(new LoginRadiusEmail() { Type = "Primary", Value = txt_email.Text });
                    userprofile.FirstName = hdFirstName.Value;
                    userprofile.LastName = hdLastName.Value;
                    userprofile.MiddleName = hdMiddleName.Value;
                    userprofile.ProfileName = hdProfileName.Value;

                    

                    LoginRadiusLogin(userprofile);



                    PopupVisiblity(false);

                }

            }
            else
            {
                PopupVisiblity(true);

            }
        }

        private static void LoginRadiusLogin(BasicUserLoginRadiusUserProfile userprofile)
        {
            //genarate password
            string password = Guid.NewGuid().ToString();

            //create user
            Membership.CreateUser(userprofile.ID, password, userprofile.Email[0].Value);

            //roles 
            Roles.AddUserToRole(userprofile.ID, "Commentor");

            //user profile
            var pf = AuthorProfile.GetProfile(userprofile.ID) ?? new AuthorProfile(userprofile.ID);

            DateTime birthdate = new DateTime();
            DateTime.TryParse(userprofile.BirthDate ?? "", out birthdate);
            pf.Birthday = birthdate;


            pf.DisplayName = userprofile.ProfileName ?? "";
            pf.EmailAddress = userprofile.Email[0].Value ?? "";
            pf.FirstName = userprofile.FirstName ?? "";

            pf.LastName = userprofile.LastName ?? "";
            pf.MiddleName = userprofile.MiddleName ?? "";

            pf.Save();

            //set logged in user
            Security.AuthenticateUser(userprofile.ID, password, false);
            FormsAuthentication.SetAuthCookie(userprofile.ID, false /* createPersistentCookie */);
        }

        public void PopupVisiblity(bool isvisible)
        {
            frmemail.Visible = isvisible;
            statefields.Visible = isvisible;
        }
    }
}