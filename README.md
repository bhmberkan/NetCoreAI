# 🤖 NetCoreAI

Bu proje, .NET Core platformunda OpenAI gibi harici yapay zeka servislerini kullanarak geliştirilen bir yapay zeka entegrasyon projesidir. Amaç, güçlü dil modellerini (LLM) .NET ortamında API aracılığıyla kullanmak ve pratik senaryolarda yapay zeka çözümleri üretmektir.

## 🎯 Amaç

- OpenAI gibi üçüncü parti yapay zeka API’lerini .NET Core ortamında kullanmak  
- Konsol tabanlı örneklerle AI servislerinin nasıl entegre edileceğini göstermek  
- Gerçek hayatta kullanılabilecek küçük, modüler örnek uygulamalar geliştirmek  

## 🧰 Kullanılan Teknolojiler

- ✅ C#  / .NET Core 9 
- ✅ OpenAI API (ChatGPT / GPT-4 / Completion / Embedding vb.)
- ✅ Google Cloud
- ✅ RESTful API entegrasyonu
- ✅ `HttpClient`, `HttpRequestMessage`, `async/await` yapıları
- ✅ APİ / UI katmanları.

## 🧠 Uygulama Özellikleri

- 🔌 OpenAI API bağlantısı kurulumu  
- 👨🏼‍🎓 Google Cloud API bağlantısı kurulumu
- ✉️ Prompt gönderme ve yanıt alma  
- 🧾 Yanıtların konsola yazdırılması veya işlenmesi  
- 🪪 Yaıtkarın web ortamında Kullanılmas
- 🔐 API anahtarı yönetimi (gizlilik odaklı)

## 📁 Proje Yapısı

```text
NetCoreAI/
├── Program.cs              # Console uygulamaları  giriş noktası
├── Services/
│   └── ViewModels/   
│      └── OpenAIService.cs


├── NetCoreAI/                # Web uygulamaları giriş noktası
│    └── İlgili Proje   
│         └── Models   
│              └── OpenAIService.cs
│───── Controller   
│      └── DefaultController.cs
│───── View   
│      └── Default.Cshtml

```

## 📸 **Proje Görselleri**

Proje Görselleri Eklenecek.

<br/>
## 🛠 Kurulum

1. Reponun klonlanması:

```bash
git clone https://github.com/bhmberkan/NetCoreAI.git
cd NetCoreAI
```

2. Gerekli NuGet paketleri (isteğe bağlı olarak `Newtonsoft.Json` gibi):

```bash
dotnet add package Newtonsoft.Json
```

3. API anahtarınızı `.env`, `appsettings.json` ya da doğrudan kodda geçici olarak tanımlayın.

## 🚀 Uygulamayı Çalıştır

```bash
dotnet build
dotnet run
```

Konsola bir prompt girerek OpenAI’den gelen yanıtı görebilirsiniz.

## 🔐 Güvenlik Notu

Lütfen API anahtarınızı doğrudan kod içerisine sabitlemeyin. Geliştirme ortamında `.gitignore` içinde olan `appsettings.Development.json` veya `user-secrets` kullanmanız önerilir.



## 📄 Lisans

Bu proje MIT lisansı ile lisanslanmıştır. Ayrıntılar için `LICENSE` dosyasına göz atabilirsiniz.

---

© 2025 Berkan Burak Turgut – .NET Core ile Harici AI API Entegrasyonları
