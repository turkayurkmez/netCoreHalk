var builder = WebApplication.CreateBuilder(args);

//uygulamanızda kullanacağınız tüm alt yapıyı buradan ekleyeceksiniz...
builder.Services.AddControllersWithViews();


//build edildikten sonra uygulamanız oluşacak
var app = builder.Build();
/*
 * Middleware: Bir httpRequest üzerinde gerçekleştirilen her bir adım.
 * Pipeline: Middleware'lerin hangi sırayla çalışacağını belirleyen akış:
 * 
 * app.UseEtiket() --> şişelere etiket bass
 * app.UseSodaDoldur() --> şişeleri doldur
 * app.UseKapat() --> kapaklarını kapat
 * app.UsePaketle() --> Şişeleri paketle
 */
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

//app.UseAuthorization();



app.MapControllerRoute(name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
