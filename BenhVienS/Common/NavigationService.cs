using BenhVienS.Enums;
using System.Windows.Forms;

namespace BenhVienS.Common
{
    public static class NavigationService
    {
        public static void RedirectByRole(Form currentForm)
        {
            var auth = AppContextCustom.Instance.Auth;
            var role = (RoleEnum)auth.CurrentUser.Role;
            Form nextForm = null;
            switch (role)
            {
                case RoleEnum.Admin:
                    nextForm = new DuocSi();
                    break;

                case RoleEnum.Doctor:
                    nextForm = new Bacsi();
                    break;

                case RoleEnum.Receptionist:
                    nextForm = new LeTan();
                    break;

                case RoleEnum.Cashier:
                    nextForm = new Thungan();
                    break;

                case RoleEnum.Pharmacist:
                    nextForm = new DuocSi();
                    break;

                default:
                    nextForm = null;
                    break;
            }


            if (nextForm == null)
            {
                MessageBox.Show("Không có quyền truy cập");
                auth.Clear();
                return;
            }

            nextForm.Show();
            currentForm.Hide();
        }
    }
}
