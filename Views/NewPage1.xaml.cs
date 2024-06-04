namespace PrimerProyectoMovil2.Views;

public partial class NewPage1 : ContentPage
{
    FileResult photo;
	public NewPage1()
	{
        InitializeComponent();
	}


    //Conversion a base 64
    public String GetImage64()
    {
        String Base64= String.Empty;
        if(photo != null)
        {
            using(MemoryStream stream = new MemoryStream())
            {
                Stream ms = photo.OpenReadAsync().Result;
                stream.CopyTo(stream);
                byte[] data = stream.ToArray();

                Base64=Convert.ToBase64String(data);
                return Base64;
            }
        }
        return Base64;
    }

    //Convertir a array
    public byte[] GetImageArray()
    {
        byte[] data=new byte[0];
        if (photo != null)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Stream ms = photo.OpenReadAsync().Result;
                stream.CopyTo(stream);
                data = stream.ToArray();

                return data;
            }
        }
        return data;
    }

    private async void btnAceptar_Clicked(object sender, EventArgs e)
    {
        var person = new Models.Personas
        {
            Nombres = Nombres.Text,
            Apellidos = Apellidos.Text,
            FechaNac = FechaNac.Date,
            Telefono = Telefono.Text
        };

        if (await App.DataBase.StorePerson(person) > 0)
        {
            await DisplayAlert("Aviso", "Registro ingresado con exito!!", "OK");
        }
    }

    private async void btnFoto_Clicked(object sender, EventArgs e)
    {
        photo = await MediaPicker.Default.CapturePhotoAsync();

        if(photo != null)
        {
            String Localizacion = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
        }
    }
}