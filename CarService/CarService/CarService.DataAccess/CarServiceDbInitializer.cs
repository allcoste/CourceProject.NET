using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Models;

namespace CarService.DataAccess {

    // инициализатор таблиц БД
    class CarServiceDbInitializer: DropCreateDatabaseIfModelChanges<CarServiceDbContext> {

        protected override void Seed(CarServiceDbContext db) {

            base.Seed(db);

            // марки автомобилей
            Brand[] brands = {
                new Brand { Name = "Ваз"},
                new Brand { Name = "Bentley"},
                new Brand { Name = "Toyota"},
                new Brand { Name = "Jeep"},
                new Brand { Name = "Volkswagen"}
            };
            db.Brands.AddRange(brands);

            // специальности
            Specialty[] specialties = {
                new Specialty { Profession = "Слесарь"},
                new Specialty { Profession = "Сварщик"},
                new Specialty { Profession = "Шиномонтажник"},
                new Specialty { Profession = "Электрик"},
                new Specialty { Profession = "Механик"},
                new Specialty { Profession = "Маляр"},
                new Specialty { Profession = "Токарь"},
                new Specialty { Profession = "Фрезеровщик"}
            };
            db.Specialties.AddRange(specialties);

            // услуги - у каждой специальности свои
            Service[] services = {
                new Service { Name = "Замена прокладки ГБЦ",         Cost = 600,  Specialty = specialties[0] },
                new Service { Name = "Замена прокладок коллекторов", Cost = 400,  Specialty = specialties[0] },
                new Service { Name = "Замена сайлентблоков",         Cost = 1000, Specialty = specialties[0] },
                new Service { Name = "Замена ступичных подшипников", Cost = 400,  Specialty = specialties[0] },
                new Service { Name = "Замена датчика кислорода",     Cost = 200,  Specialty = specialties[0] },
                new Service { Name = "Замена радиатора отопителя",   Cost = 300,  Specialty = specialties[0] },
                new Service { Name = "Замена крыла",       Cost = 2000, Specialty = specialties[1] },
                new Service { Name = "Замена порога",      Cost = 3000, Specialty = specialties[1] },
                new Service { Name = "Замена пола",        Cost = 2000, Specialty = specialties[1] },
                new Service { Name = "Ремонт арки колеса", Cost = 1000, Specialty = specialties[1] },
                new Service { Name = "Ремонт двери",       Cost = 1000, Specialty = specialties[1] },
                new Service { Name = "Подкачка колеса",     Cost = 5,   Specialty = specialties[2] },
                new Service { Name = "Балансировка колеса", Cost = 20,  Specialty = specialties[2] },
                new Service { Name = "Замена покрышки",     Cost = 100, Specialty = specialties[2] },
                new Service { Name = "Ремонт колеса",       Cost = 150, Specialty = specialties[2] },
                new Service { Name = "Замена колеса",       Cost = 100, Specialty = specialties[2] },
                new Service { Name = "Ремонт генератора",       Cost = 400, Specialty = specialties[3] },
                new Service { Name = "Ремонт стартера",         Cost = 400, Specialty = specialties[3] },
                new Service { Name = "Ремонт распр. зажигания", Cost = 300, Specialty = specialties[3] },
                new Service { Name = "Ремонт блока управления", Cost = 800, Specialty = specialties[3] },
                new Service { Name = "Ремонт электропроводки",  Cost = 600, Specialty = specialties[3] },
                new Service { Name = "Ремонт рулевого редуктора",      Cost = 600,  Specialty = specialties[4] },
                new Service { Name = "Ремонт редуктора заднего моста", Cost = 1300, Specialty = specialties[4] },
                new Service { Name = "Ремонт КПП",                     Cost = 1500, Specialty = specialties[4] },
                new Service { Name = "Замена поршневых колец",         Cost = 1300, Specialty = specialties[4] },
                new Service { Name = "Замена сальников клапанов",      Cost = 800,  Specialty = specialties[4] },
                new Service { Name = "Покраска кузова",       Cost = 30000, Specialty = specialties[5] },
                new Service { Name = "Покраска элем. кузова",   Cost = 2000,  Specialty = specialties[5] },
                new Service { Name = "Антикор. обработка",    Cost = 5000,  Specialty = specialties[5] },
                new Service { Name = "Лакировка кузова",      Cost = 5000,  Specialty = specialties[5] },
                new Service { Name = "Полировка кузова",      Cost = 2000,  Specialty = specialties[5] },
                new Service { Name = "Подготовка к покраске", Cost = 12000, Specialty = specialties[5] },
                new Service { Name = "Расточка цилиндров",         Cost = 2000, Specialty = specialties[6] },
                new Service { Name = "Шлифовка коленчатовго вала", Cost = 1500, Specialty = specialties[6] },
                new Service { Name = "Фрезеровка плоскости ГБЦ", Cost = 500, Specialty = specialties[7] },
                new Service { Name = "Фрезеровка плоскости БЦ",  Cost = 500, Specialty = specialties[7] }
            };
            db.Services.AddRange(services);

            // персоны - 11 работников и 15 клиентов
            Person[] people = {
                // работники
                new Person { Surname = "Дмитриев",   Name = "Магсум",   Patronymic = "Вениаминович",  Passport = "РН456582", DateOfBirth = new DateTime(1979, 8, 3),   Registration = "Москва, ул. Кудринский пер, 198/415" },
                new Person { Surname = "Калашников", Name = "Ревгат",   Patronymic = "Кириллович",    Passport = "ВР456129", DateOfBirth = new DateTime(1999, 11, 26), Registration = "Боготол, ул. Камышенская, 107/488" },
                new Person { Surname = "Соколович",  Name = "Авсаний",  Patronymic = "Викторович",    Passport = "АИ456192", DateOfBirth = new DateTime(1998, 3, 18),  Registration = "Юдино, ул. Перова, 30/702" },
                new Person { Surname = "Сахарова",   Name = "Малена",   Patronymic = "Станиславовна", Passport = "ВН152484", DateOfBirth = new DateTime(1997, 3, 4),   Registration = "Майкоп, ул. Макарова наб, 79/414" },
                new Person { Surname = "Пресняков",  Name = "Панасий",  Patronymic = "Федорович",     Passport = "ЕН154896", DateOfBirth = new DateTime(1988, 4, 5),   Registration = "Большая Черниговка, ул. Казарма 23 км тер, 45/927" },
                new Person { Surname = "Иванова",    Name = "Мунзира",  Patronymic = "Иосифовна",     Passport = "ОЛ341963", DateOfBirth = new DateTime(1976, 7, 20),  Registration = "Мордовское, ул. Ленинградское ш, 138/157" },
                new Person { Surname = "Жданова",    Name = "Дельвина", Patronymic = "Антоновна",     Passport = "ОИ458712", DateOfBirth = new DateTime(2000, 2, 26),  Registration = "Тевриз, ул. Даурская, 161/598" },
                new Person { Surname = "Сочинская",  Name = "Джинна",   Patronymic = "Эдуардовна",    Passport = "ЕА459696", DateOfBirth = new DateTime(1988, 1, 13),  Registration = "Вилючинск, ул. Рословка, 86/620" },
                new Person { Surname = "Изофатова",  Name = "Гайа",     Patronymic = "Петровна",      Passport = "НИ325698", DateOfBirth = new DateTime(1971, 4, 17),  Registration = "Большеустьикинское, ул. Воровского пл, 118/596" },
                new Person { Surname = "Ильина",     Name = "Лоринда",  Patronymic = "Михайловна",    Passport = "АВ887152", DateOfBirth = new DateTime(1987, 8, 6),   Registration = "Тумановка, ул. Зборовский 1-й пер, 62/870" },
                new Person { Surname = "Сидорова",   Name = "Аниссия",  Patronymic = "Геннадиевна",   Passport = "ИМ324595", DateOfBirth = new DateTime(1981, 8, 21),  Registration = "Пышма, ул. Кьтуры пл, 92/314" },
                
                // клиенты
                new Person { Surname = "Пименов",       Name = "Дозен",    Patronymic = "Русланович",    Passport = "РА516892", DateOfBirth = new DateTime(1995, 11, 24), Registration = "Куйбышево, ул. Мжд Рижское 8-й км, 192/997" },
                new Person { Surname = "Усачёв",        Name = "Армак",    Patronymic = "Вячеславович",  Passport = "АВ549562", DateOfBirth = new DateTime(1970, 9, 23),  Registration = "Гаврилово, ул. Ионосферная, 41/519" },
                new Person { Surname = "Белякова",      Name = "Вауфа",    Patronymic = "Игоревна",      Passport = "РА122321", DateOfBirth = new DateTime(1990, 3, 30),  Registration = "Икряное, ул. Тургенева, 119/623" },
                new Person { Surname = "Ивлева",        Name = "Дельфия",  Patronymic = "Олеговна",      Passport = "ПМ125321", DateOfBirth = new DateTime(1986, 5, 22),  Registration = "Вурнары, ул. Неманский проезд, 62/530" },
                new Person { Surname = "Муравьев",      Name = "Забур",    Patronymic = "Петрович",      Passport = "МО568946", DateOfBirth = new DateTime(2000, 9, 14),  Registration = "Кадошкино, ул. Пакгаузное ш, 149/878" },
                new Person { Surname = "Пчёлкин",       Name = "Бранч",    Patronymic = "Кириллович",    Passport = "РП648951", DateOfBirth = new DateTime(1985, 9, 11),  Registration = "Ершов, ул. Крашенинникова 3-й пер, 54/739" },
                new Person { Surname = "Белякова",      Name = "Амелина",  Patronymic = "Георгиевна",    Passport = "РА948464", DateOfBirth = new DateTime(1986, 1, 1),   Registration = "Лопатино, ул. Партизанская (Шувалово), 142/283" },
                new Person { Surname = "Рзаева",        Name = "Дамиля",   Patronymic = "Ярославовна",   Passport = "ОА564954", DateOfBirth = new DateTime(1999, 8, 12),  Registration = "Верхние Киги, ул. Звенигородская (Центральный), 24/695" },
                new Person { Surname = "Богачев",       Name = "Идеал",    Patronymic = "Альбертович",   Passport = "ВС815249", DateOfBirth = new DateTime(1987, 2, 16),  Registration = "Сарманово, ул. Сурикова проезд, 162/728" },
                new Person { Surname = "Третьяков",     Name = "Хамиль",   Patronymic = "Александрович", Passport = "НР957468", DateOfBirth = new DateTime(1978, 5, 28),  Registration = "Лабытнанги, ул. Максимова, 169/360" },
                new Person { Surname = "Дементьева",    Name = "Айнаша",   Patronymic = "Тимофеевна",    Passport = "ГС345156", DateOfBirth = new DateTime(1983, 1, 25),  Registration = "Ломово, ул. Верхняя, 97/39" },
                new Person { Surname = "Алексеева",     Name = "Альмаз",   Patronymic = "Андреевна",     Passport = "РО623516", DateOfBirth = new DateTime(1981, 7, 18),  Registration = "Токаревка, ул. Гороховая (Адмиралтейский), 70/627" },
                new Person { Surname = "Русов",         Name = "Виджайл",  Patronymic = "Викторович",    Passport = "МА153249", DateOfBirth = new DateTime(1991, 5, 21),  Registration = "Выборг, ул. Лефортовский пер, 35/705" },
                new Person { Surname = "Санина",        Name = "Дозина",   Patronymic = "Ермаковна",     Passport = "УН685945", DateOfBirth = new DateTime(1984, 8, 29),  Registration = "Строитель, ул. Прямикова, 91/85" },
                new Person { Surname = "Рубенцов",      Name = "Гриша",    Patronymic = "Владимирович",  Passport = "ОС123245", DateOfBirth = new DateTime(1977, 1, 19),  Registration = "Краснокамск, ул. Рахмановский пер, 44/185" }
            };
            db.People.AddRange(people);

            // автомобили
            Car[] cars = { 
                // ваз
                new Car { Brand = brands[0], Model = "2101", Color = "Синий",    Year = 1970, RegNumber = "А135АХ", Owner = people[11] },
                new Car { Brand = brands[0], Model = "2106", Color = "Бежевый",  Year = 1995, RegNumber = "В903ММ", Owner = people[12] },
                new Car { Brand = brands[0], Model = "2108", Color = "Вишневый", Year = 2000, RegNumber = "А157АА", Owner = people[13] },
                
                // bentley
                new Car { Brand = brands[1], Model = "Continental GT W12",    Color = "Вишневый",  Year = 2019, RegNumber = "А811КК", Owner = people[14] },
                new Car { Brand = brands[1], Model = "Continental GT W8",     Color = "Вишневый",  Year = 2019, RegNumber = "В033АН", Owner = people[15] },
                new Car { Brand = brands[1], Model = "Continental GT W12",    Color = "Черный",    Year = 2019, RegNumber = "А406НК", Owner = people[16] },
                new Car { Brand = brands[1], Model = "Bentayga V8 Petrol",    Color = "Оранжевый", Year = 2019, RegNumber = "А002АА", Owner = people[17] },
                new Car { Brand = brands[1], Model = "Mulsanne W.O. Edition", Color = "Черный",    Year = 2019, RegNumber = "А819АН", Owner = people[18] },
                
                // toyota
                new Car { Brand = brands[2], Model = "Camry",   Color = "Белый", Year = 2019, RegNumber = "В017РО", Owner = people[19] },
                new Car { Brand = brands[2], Model = "Rav4",    Color = "Белый", Year = 2019, RegNumber = "А938ВТ", Owner = people[20] },
                new Car { Brand = brands[2], Model = "Corolla", Color = "Белый", Year = 2019, RegNumber = "А220НК", Owner = people[21] },
                new Car { Brand = brands[2], Model = "Hilux",   Color = "Белый", Year = 2019, RegNumber = "А299ЕК", Owner = people[22] },
                new Car { Brand = brands[2], Model = "C-HR",    Color = "Белый", Year = 2019, RegNumber = "А048ОС", Owner = people[23] },
                
                // jeep
                new Car { Brand = brands[3], Model = "Grand Cherokee", Color = "Белый",    Year = 2019, RegNumber = "В398ЕС", Owner = people[24] },
                new Car { Brand = brands[3], Model = "Renegade",       Color = "Вишневый", Year = 2019, RegNumber = "А666АА", Owner = people[25] },
                new Car { Brand = brands[3], Model = "Compass",        Color = "Белый",    Year = 2019, RegNumber = "А801ЕЕ", Owner = people[21] },
                new Car { Brand = brands[3], Model = "Grand Cherokee", Color = "Вишневый", Year = 2019, RegNumber = "В909ОН", Owner = people[11] },
                
                // volkswagen
                new Car { Brand = brands[4], Model = "Touareg", Color = "Белый",  Year = 2020, RegNumber = "А808ВУ", Owner = people[18] },
                new Car { Brand = brands[4], Model = "Tiguan",  Color = "Серый",  Year = 2020, RegNumber = "А108АА", Owner = people[13] },
                new Car { Brand = brands[4], Model = "T-Roc",   Color = "Черный", Year = 2020, RegNumber = "А555УТ", Owner = people[17] }
            };
            db.Cars.AddRange(cars);

            // клиенты - 15 персон, начиная с 12-го
            Client[] clients = { 
            
                new Client { Person = people[11], PhoneNumber = "+380952829962" },
                new Client { Person = people[12], PhoneNumber = "+380957346268" },
                new Client { Person = people[13], PhoneNumber = "+380955587784" },
                new Client { Person = people[14], PhoneNumber = "+380954483548" },
                new Client { Person = people[15], PhoneNumber = "+380959358334" },
                new Client { Person = people[16], PhoneNumber = "+380952782275" },
                new Client { Person = people[17], PhoneNumber = "+380953663885" },
                new Client { Person = people[18], PhoneNumber = "+380953476767" },
                new Client { Person = people[19], PhoneNumber = "+380956263244" },
                new Client { Person = people[20], PhoneNumber = "+380955777765" },
                new Client { Person = people[21], PhoneNumber = "+380955859678" },
                new Client { Person = people[22], PhoneNumber = "+380957984737" },
                new Client { Person = people[23], PhoneNumber = "+380959337345" },
                new Client { Person = people[24], PhoneNumber = "+380958673799" },
                new Client { Person = people[25], PhoneNumber = "+380957839983" }
            };
            db.Clients.AddRange(clients);

            // работники - 11 первых персон 
            Worker[] workers = {
                new Worker { Specialty = specialties[0], Person = people[0],  Busy = false, Discharge = 2, WorkExperience = 2, Salaried = true },
                new Worker { Specialty = specialties[1], Person = people[1],  Busy = false, Discharge = 2, WorkExperience = 0, Salaried = true },
                new Worker { Specialty = specialties[2], Person = people[2],  Busy = false, Discharge = 2, WorkExperience = 4, Salaried = true },
                new Worker { Specialty = specialties[3], Person = people[3],  Busy = false, Discharge = 5, WorkExperience = 4, Salaried = true },
                new Worker { Specialty = specialties[4], Person = people[4],  Busy = false, Discharge = 5, WorkExperience = 4, Salaried = true },
                new Worker { Specialty = specialties[5], Person = people[5],  Busy = false, Discharge = 3, WorkExperience = 5, Salaried = true },
                new Worker { Specialty = specialties[6], Person = people[6],  Busy = false, Discharge = 4, WorkExperience = 0, Salaried = true },
                new Worker { Specialty = specialties[7], Person = people[7],  Busy = false, Discharge = 2, WorkExperience = 3, Salaried = true },
                new Worker { Specialty = specialties[0], Person = people[8],  Busy = false, Discharge = 3, WorkExperience = 5, Salaried = true },
                new Worker { Specialty = specialties[4], Person = people[9],  Busy = false, Discharge = 2, WorkExperience = 2, Salaried = true },
                new Worker { Specialty = specialties[5], Person = people[10], Busy = false, Discharge = 2, WorkExperience = 0, Salaried = true }
            };
            db.Workers.AddRange(workers);


            // запчасти к автомобилям
            SparePart[] spareParts = {
                new SparePart { Name = "Прокладка ГБЦ",             Cost = 300 },
                new SparePart { Name = "Прокладки коллекторов",     Cost = 75 },
                new SparePart { Name = "К-т ступичных подшипников", Cost = 400 },
                new SparePart { Name = "Датчик кислорода",          Cost = 300 },
                new SparePart { Name = "Радиатор отопителя",        Cost = 1000 },
                new SparePart { Name = "Шина R13 175/70",           Cost = 2000 },
                new SparePart { Name = "Подшипники генератора",     Cost = 500 },
                new SparePart { Name = "Втягивающее реле",          Cost = 500 },
                new SparePart { Name = "Предохранитель 5А",         Cost = 10 },
                new SparePart { Name = "Червячный вал",             Cost = 200 },
                new SparePart { Name = "Синхронная муфта",          Cost = 600 },
                new SparePart { Name = "Жгут проводов",             Cost = 200 },
                new SparePart { Name = "Щетки",                     Cost = 100 },
                new SparePart { Name = "Якорь",                     Cost = 1500 },
                new SparePart { Name = "Кулиса",                    Cost = 200 },
                new SparePart { Name = "Сальники клапанов",         Cost = 400 },
                new SparePart { Name = "Поршневые кольца",          Cost = 1200 },
                new SparePart { Name = "Шкив",                      Cost = 300 },
                new SparePart { Name = "Бендикс",                   Cost = 350 },
                new SparePart { Name = "Колокол",                   Cost = 1400 }
            };
            db.spareParts.AddRange(spareParts);

            // сервисные листы


            // акты о выполненных работах

        }
    }
}
