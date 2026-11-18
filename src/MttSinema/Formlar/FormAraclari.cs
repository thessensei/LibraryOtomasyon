using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Windows.Forms;
using MttSinema.Veri;

namespace MttSinema.Formlar
{
    internal static class FormAraclari
    {
        internal static string Para(decimal tutar) => tutar.ToString("N2", CultureInfo.GetCultureInfo("tr-TR")) + " TL";

        internal static void Dene(this Form form, Action islem)
        {
            try { islem(); }
            catch (KayitHatasi ex)
            {
                MessageBox.Show(form, ex.Message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbException ex)
            {
                MessageBox.Show(form, "Veritabanı işlemi tamamlanamadı.\n\n" + ex.Message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal static bool Onayla(this Form form, string soru) => MessageBox.Show(form, soru, form.Text,
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;

        internal static T Secili<T>(this ListView liste) where T : class =>
            liste.SelectedItems.Count == 0 ? null : (T)liste.SelectedItems[0].Tag;

        internal static void Doldur<T>(this ListView liste, IEnumerable<T> kayitlar, Func<T, string[]> hucreler)
        {
            liste.BeginUpdate();
            try
            {
                liste.Items.Clear();
                foreach (var kayit in kayitlar)
                    liste.Items.Add(new ListViewItem(hucreler(kayit)) { Tag = kayit });
            }
            finally { liste.EndUpdate(); }
        }
    }
}
