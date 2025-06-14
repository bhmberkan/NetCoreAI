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


<br/>
Recipe Suggestion
<br/>

![AITarifÖner](https://github.com/user-attachments/assets/c0d10067-a63a-411d-b73a-92559e3cfcbb)
<br/>

Rapid Api Top 100 films
<br/>

![image](https://github.com/user-attachments/assets/49fcb5c3-d0c7-4c3b-a047-16443f52931a)
<br/>
AI Chat
<br/>
![image](https://github.com/user-attachments/assets/7926d749-1fa3-4865-af86-c2c8f474e881)
<br/>
Open Whisper Audio Transkript
<br/>
![image](https://github.com/user-attachments/assets/76689b9e-722c-4e29-841b-fd4364997fd7)
<br/>
DallE Image Generation
<br/>
![image](https://github.com/user-attachments/assets/69844e4b-a649-4728-967d-d48e178a6153)
<br/>
Tesseract Ocr
<br/>

![image](https://github.com/user-attachments/assets/d22c1085-3639-4299-adbc-3590eae1b9eb)
<br/>

<br/>
Google Cloud Vision ile Resim üzerindeki Yazıların okunması.
<br/>

![image](https://github.com/user-attachments/assets/10e711e1-0128-4c85-8889-d9daf80eeb07)
<br/>
Open AI Translate
<br/>

![image](https://github.com/user-attachments/assets/465bcb2b-118b-4653-9edf-2ba47e0eee3f)

<br/>
Text To Speech
<br/>



![image](https://github.com/user-attachments/assets/0843c4f0-d14c-4231-9c85-c221347f4ab4)
<br/>

![image](https://github.com/user-attachments/assets/b30be404-c661-4581-84e2-37cb20b93347)
<br/>

![image](https://github.com/user-attachments/assets/62c08ee3-1b7f-4078-920d-f877306eb352)
<br/>
Sentiment With Degree AI App
<br/>

![image](https://github.com/user-attachments/assets/8507528b-7e4d-4c54-a8b5-0e66ff0d8667)
<br/>

![image](https://github.com/user-attachments/assets/aaed2754-118f-42c4-af37-6720c65572eb)
<br/>
Article Summarize AI
<br/>

![image](https://github.com/user-attachments/assets/f07e00ed-6a33-47d8-9442-fb62cbaac5c7)
<br/>
![image](https://github.com/user-attachments/assets/41007e8c-1204-4c9b-a75f-ccd658e03fa4)
<br/>

![image](https://github.com/user-attachments/assets/91f8436a-e8cf-41f4-913f-5bc4634441d3)
<br/>
Web Scraping With OpenAI
<br/>

![image](https://github.com/user-attachments/assets/17ebfb40-6a48-4bc8-b8fd-6ce94c3f4822)
<br/>
Pdf Analyze With AI
<br/>

![image](https://github.com/user-attachments/assets/95bbee1a-00a9-48bc-8c1c-98a63d2ff532)
<br/>
Google Cloud Vision Image Detection
<br/>

![image](https://github.com/user-attachments/assets/a73149a2-263e-404a-825d-05d19354b5fa)
<br/>
Open AI News Summarize With Rss<br/>

![rss](https://github.com/user-attachments/assets/6583148b-6870-4c8c-a6db-5c2c9b58287c)
<br/>
Create Story With AI<br/>
![CreateStroy](https://github.com/user-attachments/assets/4164324e-0875-454e-a2fd-70b309b41bec)
<br/>
![CreateStroyWithAI](https://github.com/user-attachments/assets/ab024748-d213-40e4-b574-c2666ea634f7)
<br/> 
<br/>
![image](https://github.com/user-attachments/assets/631dc8d8-da3d-4ec9-9113-11ba537d57f0)
<br/>
![image](https://github.com/user-attachments/assets/69c14ced-ba61-499f-8b38-7f25901c2ef2)



<br/>
<br/>

## **🛠 Kurulum**

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
