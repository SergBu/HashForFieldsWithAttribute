﻿// See https://aka.ms/new-console-template for more information

using HashForFieldsAttribute;
using Moq.AutoMock;
using System.Collections;
using System.Net;
using System.Security.Cryptography;

Console.WriteLine("Windows - 1251 она же CP1251 она же ANSI ) и пятая(CP866 она же OEM или DOS");
Console.WriteLine("Windows для работы с кириллицей в консоли по-умолчанию использует кодировку CP866 (русские символы такие же как в «альтернативной кодировке», только некоторые спецсимволы отличаются), для других целей — кодировку CP1251");

//incoding
var inputBytes = System.Text.Encoding.UTF8.GetBytes("hello");
string result = System.Text.Encoding.ASCII.GetString(inputBytes);
Console.WriteLine($"{result} : {Convert.ToHexString(inputBytes)}");

inputBytes = System.Text.Encoding.UTF8.GetBytes("привэ");
result = System.Text.Encoding.ASCII.GetString(inputBytes);
Console.WriteLine($"{result} : {Convert.ToHexString(inputBytes)}");
Console.WriteLine($"привэ в UTF8 {Convert.ToHexString(inputBytes)}");

inputBytes = System.Text.Encoding.ASCII.GetBytes("привэ");
Console.WriteLine($"привэ в ASCII {Convert.ToHexString(inputBytes)}");

inputBytes = System.Text.Encoding.BigEndianUnicode.GetBytes("привэ");
Console.WriteLine($"привэ в BigEndianUnicode {Convert.ToHexString(inputBytes)}");

inputBytes = System.Text.Encoding.Latin1.GetBytes("привэ");
Console.WriteLine($"привэ в Latin1 {Convert.ToHexString(inputBytes)}");

inputBytes = System.Text.Encoding.Unicode.GetBytes("привэ");
Console.WriteLine($"привэ в Unicode {Convert.ToHexString(inputBytes)}");

inputBytes = System.Text.Encoding.UTF32.GetBytes("привэ");
Console.WriteLine($"привэ в UTF32 {Convert.ToHexString(inputBytes)}");

inputBytes = System.Text.Encoding.UTF7.GetBytes("привэ");
Console.WriteLine($"привэ в UTF7 {Convert.ToHexString(inputBytes)}");

//hash
var mocker = new AutoMocker();
var request = mocker.CreateInstance<AbonentDto>();

var hash = Md5Calculator.GetHashKey(request.GetStringForHash());
Console.WriteLine($"MD5 hash is: {hash}");

//Решением стала разработанная фирмой IBM технология кодовых страниц. К этому времени «контрольный символ» при передаче потерял свою актуальность и все 8-бит можно было использовать для кода символа. Вместо диапазона кодов 0-127 стал доступен диапазон 0-255. Кодовая страница (или кодировка)– это сопоставление кода из диапазона 0-255 некоему графическому образу (например, букве «Я» кириллицы или букве «омега» греческого). Нельзя сказать «символ с кодом 211 выглядит так», но можно сказать «символ с кодом 211 в кодовой странице CP1251 выглядит так: У, а в CP1253(греческая) выглядит так: Σ ». Во всех (или почти всех) кодовых таблица первые 128 кодов соответствуют таблице ASCII, только для первых 32 непечатных кодов IBM «назначила» свои картинки (которые показывается при выводе на экран монитора). В верхней части IBM разместила символы псевдографики (для рисования различных рамок), дополнительные символы латиницы, используемые в странах Западной Европы, некоторые математические символы и отдельные символы греческого алфавита. Эта кодовая страница получила название CP437 

//После массового перехода на Windows к трем кодовым страницам добавилась четвертая (Windows-1251 она же CP1251 она же ANSI ) и пятая (CP866 она же OEM или DOS). Не удивляйтесь — Windows для работы с кириллицей в консоли по-умолчанию использует кодировку CP866 (русские символы такие же как в «альтернативной кодировке», только некоторые спецсимволы отличаются), для других целей — кодировку CP1251. Почему Windows понадобилось две кодировки, неужели нельзя было обойтись одной? Увы, не получается: DOS - кодировка используется в именах файлов (тяжелое наследие DOS) и консольные команды типа dir, copy должны правильно показывать и правильно обрабатывать досовские имена файлов. С другой стороны, в этой кодировке много кодов отведено символам псевдографики (различным рамкам и т.п.), а Windows работает в графическом режиме и ей (а точнее, windows-приложениям) не нужны символы псевдографики (но нужны занятые ими коды, которые в CP1251 использованы для других полезных символов). Пять кириллических кодировок поначалу еще больше усугубили ситуацию, но со временем наиболее популярными стали Windows-1251 и KOI8, а досовскими просто стали меньше пользоваться. Еще при использовании Windows стало неважно, какая кодировка в видеоадаптере (только изредка, до загрузки Windows в диагностических сообщениях можно видеть «кракозябры»).

//Решение проблемы кодировок пришло, когда повсеместно стала внедряться система Unicode (и для персональных ОС и для серверов). Unicode каждому национальному символу ставит в соответствие раз и навсегда закрепленное за ним 20-ти битовое число («точку» в кодовом пространстве Unicode, причем чаще всего хватает 16 бит, поскольку 20-битные коды используются для редких символов и иероглифов), поэтому нет необходимости перекодировать (подробнее об Unicode см следующую запись в журнале). Теперь для любой пары <код байта>+<кодовая страница> можно определить соответствующий ей код в Unicode (сейчас в кодовых страницах для каждого 8-битного кода показывается 16-битный код Unicode) и потом при необходимости вывести этот символ для любой кодовой страницы, где он присутствует. В настоящее время проблема кодировок и перекодировок для пользователей практически исчезла, но все же изредка приходят письма, где либо тема письма либо содержание «не в той» кодировке.