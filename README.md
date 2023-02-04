# rgada-downloader

Консольное приложение для скачивания архивных материалов с сайта РГАДА (Российского государственного архива древних актов)

![screenshoot](https://raw.githubusercontent.com/okolobaxa/cgamos-downloader/master/screenshoot.png)

* Windows 7 и выше https://github.com/okolobaxa/rgada-downloader/releases/download/v1.0/RgadaDownloader.1.0.0.win-x64.zip
* MacOS https://github.com/okolobaxa/rgada-downloader/releases/download/v1.0/RgadaDownloader.1.0.0.osx-x64.tar.gz

### Инструкция
* Скачиваем нужную версию программы, распаковываем. Для Mac OS смотрите дополнительные шаги в конце
* Заходим на сайт РГАДА и открываем нужную вам опись так, чтобы была видна обложка и переключатели с номерами страниц.
* Копируем адрес страницы и вставляем его в текстовый документ download.txt в папке с программой
* Запускаем программу и следуем инструкциям. В той же папке появится новая папка с именем описи и сканами внутри. Чтобы скачать другую опись - повторяем шаги.
* Жертвуем 50р нашему краеведческому проекту "Фотографии старого Саратова" https://boosty.to/oldsaratov
* Сэкономленное время можно потратить на чтение стаьи БиБиСи об ударе российских ракет по Днепру https://github.com/okolobaxa/rgada-downloader/blob/main/bbc.pdf

Для MacOS предварительно выполните в скаченной папке команды 
```
chmod -R +x *
xattr -r -d com.apple.quarantine ./
```
