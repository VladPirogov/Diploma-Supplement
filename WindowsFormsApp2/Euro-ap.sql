-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Фев 23 2018 г., 14:18
-- Версия сервера: 5.5.53
-- Версия PHP: 7.0.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `Euro-ap`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Contents_and_results`
--

CREATE TABLE `Contents_and_results` (
  `Qualification_ID` int(110) UNSIGNED NOT NULL,
  `Form_study_UA` varchar(255) DEFAULT NULL,
  `Form_study_EN` varchar(255) DEFAULT NULL,
  `Program_Specification_UA` text,
  `Program_Specification_EN` text,
  `Knowledge_undestanding_UA` text,
  `Knowledge_undestanding_EN` text,
  `Application_knowledge_understanding_UA` text,
  `Application_knowledge_understanding_EN` text,
  `Making_judgments_UA` text,
  `Making_judgments_EN` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Contents_and_results`
--

INSERT INTO `Contents_and_results` (`Qualification_ID`, `Form_study_UA`, `Form_study_EN`, `Program_Specification_UA`, `Program_Specification_EN`, `Knowledge_undestanding_UA`, `Knowledge_undestanding_EN`, `Application_knowledge_understanding_UA`, `Application_knowledge_understanding_EN`, `Making_judgments_UA`, `Making_judgments_EN`) VALUES
(1, 'Денна', 'Full-time', '- теоретичне навчання (57 кредитів ECTS) з дисциплін у вигляді аудиторних занять (лекційні, семінарські (практичні), лабораторні заняття) і самостійної роботи. Обсяг теоретичного навчання, який забезпечує отримання базової кваліфікації з історії, складає 29 кредитів ECTS. Блок навчальних дисциплін, що забезпечує поглиблену підготовку з історії, складає 14 кредитів ECTS;\r\n- виконання кваліфікаційної (магістерської) роботи зі спеціальності (30 кредити ECTS);\r\n- проходження виробничої педагогічної практики в школі (8 тижнів, 8 кредитів ECTS);\r\n- оглядові лекції (1 кредит ECTS);\r\n- підсумкова державна атестація (2 кредити ECTS).\r\nКредити студенту зараховуються у випадку успішного складання усних заліків або іспитів із навчальної дисципліни, захисту звітів із виробничих педагогічних практик у школі й ВНЗ. Підсумкова державна атестація передбачає комплексний екзамен із правознавства та методики його викладання й захист магістерської роботи.', '- theoretical studies (57 credits ECTS) in the disciplines in the form of classes (lectures, seminars, laboratory and  classes) and individual work. Theoretical training, which provides a basic qualification in history is 29 credits  ECTS. A series of  disciplines, which provides deep training in history is 14 credits ECTS;\r\n- fulfillment of Master’s thesis in speciality (30 credits ECTS);\r\n- pedagogical training practice at school (8 weeks,  8 credits ECTS);\r\n- pedagogical training practice at higher educational institution (3 weeks, 3 credits ECTS);\r\n- review lectures  (1 credit ECTS);\r\n- final state certification (2 credits ECTS).\r\nCredits are awarded to students in case of successful  passing (evaluation criteria listed in Section 4.4) oral tests or examinations in discipline, the positive evaluation of practical training reports from practices at school and higher educational institution. Final state certification includes a comprehensive examination in jurisprudence and methods of teaching,  and the defence of  Master’s thesis. \r\n\r\n\r\n', '- володіти методологічними знаннями, методами історичного дослідження: синтезу, порівняльного аналізу, класифікації, типологізації, історико-хронологічним, історико- ситуаційним, біографічним і допоміжними (інформаційно-комунікаційними технологіями) методами;\r\n- уміти узагальнювати, готувати до публікації результати наукових досліджень;\r\n- знання та вміння аналізувати, оцінювати й порівнювати альтернативу, генерувати оригінальні ідеї в галузі історії; \r\n- володіти цінностями, необхідними для того, щоб жити в умовах демократичного суспільства, бути його відповідальним громадянином, мати необхідні соціальні компетенції;\r\n- використовувати норми чинного законодавства, уміти застосовувати їх для захисту своїх прав і свобод.\r\n', '- proficiency in methodological knowledge, methods of historical research: synthesis, comparative analysis, classification, typology, historical-chronological, historical-situational, biographical and auxiliary (information communication technology) methods;\r\n- ability to generalize, to prepare for publishing the results of scientific research;\r\n- knowledge and ability to analyze, evaluate and compare an alternative, to generate original ideas in the field of history; \r\n- possession of the values necessary to live in a democratic society, to be  a responsible citizen, to have necessary social competence;\r\n- ability to use the legal regulations to  defend the  human  rights and freedoms.\r\n', '- здатність використовувати професійно-профільовані знання в галузі педагогічної освіти й історії, правознавства для дослідження історичних явищ і процесів, виховання всебічно розвиненої особистості, громадянина;\r\n - уміти перевести одержані знання в інноваційні технології, перетворюючи нові знання в конкретні пропозиції, демонструючи творчість у застосуванні знань, досвіду, методів;\r\n- спроможність інтегрувати знання, розв\'язувати складні завдання, аргументовано доводити до аудиторії фахівців наукову інформацію та власні висновки; \r\n- застосовувати набуті знання під часи аналізу проблем історії України та всесвітньої історії, сучасного етапу розвитку людства й міжнародних відносин.\r\n', '- ability to use career-oriented knowledge in the field of pedagogical education, history and jurisprudence in research of historical  phenomena and processes, the upbringing of comprehensively developed personality of a citizen;\r\n- ability to transform the received knowledge in innovative technology into specific proposals, demonstrating creativity in the application of knowledge, experience, and  methods;\r\n- ability to solve complicated problems, to acquaint an  audience of specialists with scientific information and conclusions;\r\n- ability to apply the acquired knowledge in the analysis of problems of the Ukrainian and world history, as well as of  the current stage of humanity progress and international relations.\r\n', '- здатність логічно мислити, робити аргументовані висновки, аналізувати, моделювати та прогнозувати історичні процеси в соціумі;\r\n- здатність характеризувати й аналізувати демографічний і соціально-економічний склад населення, зміни в динаміці за регіонами тощо;\r\n- здатність використовувати професійно-профільовані знання й практичні навички для вирішення практичних завдань у галузі історії та правознавства; \r\n- спілкування державною мовою й однією з іноземних мов, здатність здобувати інформацію з історичних джерел і літератури, користуватися сучасними інформаційними технологіями;\r\n- активна участь у поліпшенні стану довкілля, забезпечення якості та безпеки життя й діяльності людини.\r\n', '- ability to think logically, to make well-reasoned conclusions, to analyze and foresee the historical processes in society;\r\n- ability to characterize and analyze the demographic and socio-economic structure of the population, regional dynamic changes etc;\r\n- ability to use career-oriented knowledge and practical skills to solve practical problems in the field of history and jurisprudence;\r\n- communication in the official language and in one foreign language, ability to extract information from  historical sources and literature, and to use modern information technologies;\r\n- active participation in the environment state improvement, ensuring quality and security of human life and activity.\r\n'),
(2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `Discipline`
--

CREATE TABLE `Discipline` (
  `Discipline_ID` int(110) NOT NULL,
  `Qualification_ID` int(110) UNSIGNED NOT NULL,
  `Course_title_UA` text,
  `Course_title_EN` text,
  `Loans` float UNSIGNED DEFAULT NULL,
  `Hours` float UNSIGNED DEFAULT NULL,
  `Teaching` float UNSIGNED DEFAULT NULL,
  `Differential` float UNSIGNED DEFAULT NULL,
  `Type(Lectures/Practical/Сertification)` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Discipline`
--

INSERT INTO `Discipline` (`Discipline_ID`, `Qualification_ID`, `Course_title_UA`, `Course_title_EN`, `Loans`, `Hours`, `Teaching`, `Differential`, `Type(Lectures/Practical/Сertification)`) VALUES
(1, 1, 'Філософія і методологія науки/Філософія історії', 'Philosophy and Methodology of Science Philosophy of history', 3, 90, 1, 1, 'Lectures'),
(2, 1, 'Міжнародне право', 'International law', 3, 90, 1, 1, 'Lectures'),
(3, 1, 'Виробнича педагогічна практика в школі', 'Pedagogical Training Practice at School', 8, 250, 2, 0, 'Practical'),
(4, 2, 'Філософія і методологія науки', 'Philosophy and Methodology of Science', 3, 90, 1, 1, 'Lectures');

-- --------------------------------------------------------

--
-- Структура таблицы `Estimates`
--

CREATE TABLE `Estimates` (
  `Graduat_ID` int(110) DEFAULT NULL,
  `Disciptine_ID` int(110) DEFAULT NULL,
  `Estimat_NUM` int(101) DEFAULT NULL,
  `Estimat_CHAR` varchar(10) DEFAULT NULL,
  `Estimat_UA` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Estimates`
--

INSERT INTO `Estimates` (`Graduat_ID`, `Disciptine_ID`, `Estimat_NUM`, `Estimat_CHAR`, `Estimat_UA`) VALUES
(1, 1, 85, 'B', 'Добре / Good'),
(1, 2, 71, 'C', 'Задовільно / Satisfactory'),
(2, 1, 90, 'A', 'Відмінно / Excellent'),
(3, 4, 80, 'D', 'Задовільно / Satisfactory');

-- --------------------------------------------------------

--
-- Структура таблицы `graduates`
--

CREATE TABLE `graduates` (
  `Qualification_ID` int(110) UNSIGNED NOT NULL,
  `Graduat_ID` int(110) NOT NULL,
  `Lastname_UA` varchar(255) NOT NULL,
  `Lastname_EN` varchar(255) NOT NULL,
  `Firstname_UA` varchar(255) NOT NULL,
  `Firstname_EN` varchar(255) NOT NULL,
  `birthday` date NOT NULL,
  `SerialDiploma` varchar(255) DEFAULT NULL,
  `NumberDiploma` varchar(255) DEFAULT NULL,
  `NumberAddition` varchar(255) DEFAULT NULL,
  `PrevDocument_UA` varchar(255) DEFAULT NULL,
  `PrevDocument_EN` varchar(255) DEFAULT NULL,
  `prevSerialNumberAddition` varchar(255) DEFAULT NULL,
  `DurationOfTraining_UA` varchar(255) DEFAULT NULL,
  `DurationOfTraining_EN` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `graduates`
--

INSERT INTO `graduates` (`Qualification_ID`, `Graduat_ID`, `Lastname_UA`, `Lastname_EN`, `Firstname_UA`, `Firstname_EN`, `birthday`, `SerialDiploma`, `NumberDiploma`, `NumberAddition`, `PrevDocument_UA`, `PrevDocument_EN`, `prevSerialNumberAddition`, `DurationOfTraining_UA`, `DurationOfTraining_EN`) VALUES
(1, 1, 'Федько ', 'Fedko', 'Дмитро Вікторович \r\n', 'Dmytro Viktorovych\r\n', '1995-11-14', 'M18', '3337', '14-2/001/2018', 'Диплом бакалавра', 'Diploma of Bachelor', 'В16  150979', '1 рік 5 місяців', '1 year 5 months'),
(1, 2, 'Плотнікова ', 'Plotnikova', 'Вікторія Ігорівна', 'Viktoriia Ihorivna', '1994-10-04', 'M18', '3337', '14-2/002/2018', 'Диплом бакалавра (з відзнакою)', 'Diploma of Bachelor', 'В16  150972', '1 рік 5 місяців', '1 year 5 months'),
(2, 3, 'Красовська ', 'Krasovska', 'Ольга Андріївна', 'Olha Andriivna', '1994-07-25', 'M18', '3338', '14-2/003/2018', 'Диплом бакалавра', 'Diploma of Bachelor', 'B16 158356', '1 рік 5 місяців', '1 year 5 months');

-- --------------------------------------------------------

--
-- Структура таблицы `National_framework`
--

CREATE TABLE `National_framework` (
  `Qualification_ID` int(110) UNSIGNED NOT NULL,
  `Level_qualification_UA` text,
  `Level_qualification_EN` text,
  `Official_duration_programme_UA` text,
  `Official_duration_programme_EN` text,
  `Access_requirements_UA` text,
  `Access_requirements_EN` text,
  `Access_further_study_UA` text,
  `Access_further_study_EN` text,
  `Professional_status_UA` text,
  `Professional_status_EN` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `National_framework`
--

INSERT INTO `National_framework` (`Qualification_ID`, `Level_qualification_UA`, `Level_qualification_EN`, `Official_duration_programme_UA`, `Official_duration_programme_EN`, `Access_requirements_UA`, `Access_requirements_EN`, `Access_further_study_UA`, `Access_further_study_EN`, `Professional_status_UA`, `Professional_status_EN`) VALUES
(1, 'Здатність розв’язувати складні задачі і проблеми у певній галузі професійної діяльності або у процесі навчання, що передбачає проведення досліджень та/або здійснення інновацій та характеризується невизначеністю умов і вимог.', 'Ability to solve complex problems and tasks in a given professional activity field either while supposes researching and/or innovations implementation under ambiguous conditions and requirements.', '1 рік 5 місяців, денна форма навчання (90 кредитів ECTS)', '1 year 5 months, full -time form of studies (90 credits ECTS)', 'Базова вища освіта, на основі результатів фахових вступних випробувань.', 'Basic higher education, on the basis of admission tests in profession.', 'Право вступу до аспірантури. ', 'Access to admission to postgraduate course.', 'Робота у сфері середньої, вищої, інших видів освіти, наукових досліджень і розробок у галузі суспільних і гуманітарних наук.', 'Employment in secondary school, in higher educational institutions, as well as in other types of education, research in the field of social and human sciences. '),
(2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `Qualification`
--

CREATE TABLE `Qualification` (
  `Qualification_ID` int(110) UNSIGNED NOT NULL,
  `Qualification_EN` text CHARACTER SET hp8,
  `Qualification_UA` text,
  `Main_field_study_UA` text,
  `Main_field_study_EN` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Qualification`
--

INSERT INTO `Qualification` (`Qualification_ID`, `Qualification_EN`, `Qualification_UA`, `Main_field_study_UA`, `Main_field_study_EN`) VALUES
(1, 'Historian. Lecturer of history. Teacher of  jurisprudence.', 'Історик. Викладач історії. Вчитель правознавства.', '014.03 Середня освіта (Історія), спеціалізація: Правознавство', '014.03 Secondary education (History), Specialization: Law'),
(2, 'Mathematician. Lecturer of Mathematics. Teacher of Informatics', 'математик. Викладач математики. Вчитель інформатики\r\n', '014.04 Середня освіта (Математика)', '014.04 Secondary education (Mathematics)');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Contents_and_results`
--
ALTER TABLE `Contents_and_results`
  ADD UNIQUE KEY `Qualification_ID` (`Qualification_ID`);

--
-- Индексы таблицы `Discipline`
--
ALTER TABLE `Discipline`
  ADD PRIMARY KEY (`Discipline_ID`),
  ADD KEY `FK_Discipline_Qualification_Qualification_ID` (`Qualification_ID`);

--
-- Индексы таблицы `Estimates`
--
ALTER TABLE `Estimates`
  ADD KEY `FK_Estimates_graduates_Graduat_ID` (`Graduat_ID`),
  ADD KEY `Disciptine_ID` (`Disciptine_ID`);

--
-- Индексы таблицы `graduates`
--
ALTER TABLE `graduates`
  ADD PRIMARY KEY (`Graduat_ID`),
  ADD KEY `FK_graduates_Qualification_Qualification_ID` (`Qualification_ID`);

--
-- Индексы таблицы `National_framework`
--
ALTER TABLE `National_framework`
  ADD UNIQUE KEY `Qualification_ID` (`Qualification_ID`);

--
-- Индексы таблицы `Qualification`
--
ALTER TABLE `Qualification`
  ADD PRIMARY KEY (`Qualification_ID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Discipline`
--
ALTER TABLE `Discipline`
  MODIFY `Discipline_ID` int(110) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT для таблицы `graduates`
--
ALTER TABLE `graduates`
  MODIFY `Graduat_ID` int(110) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT для таблицы `Qualification`
--
ALTER TABLE `Qualification`
  MODIFY `Qualification_ID` int(110) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Contents_and_results`
--
ALTER TABLE `Contents_and_results`
  ADD CONSTRAINT `FK_Contents_and_results_Qualification_Qualification_ID` FOREIGN KEY (`Qualification_ID`) REFERENCES `Qualification` (`Qualification_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ограничения внешнего ключа таблицы `Discipline`
--
ALTER TABLE `Discipline`
  ADD CONSTRAINT `FK_Discipline_Qualification_Qualification_ID` FOREIGN KEY (`Qualification_ID`) REFERENCES `Qualification` (`Qualification_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ограничения внешнего ключа таблицы `Estimates`
--
ALTER TABLE `Estimates`
  ADD CONSTRAINT `FK_Estimates_Discipline_Discipline_ID` FOREIGN KEY (`Disciptine_ID`) REFERENCES `Discipline` (`Discipline_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `FK_Estimates_graduates_Graduat_ID` FOREIGN KEY (`Graduat_ID`) REFERENCES `graduates` (`Graduat_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ограничения внешнего ключа таблицы `graduates`
--
ALTER TABLE `graduates`
  ADD CONSTRAINT `FK_graduates_Qualification_Qualification_ID` FOREIGN KEY (`Qualification_ID`) REFERENCES `Qualification` (`Qualification_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ограничения внешнего ключа таблицы `National_framework`
--
ALTER TABLE `National_framework`
  ADD CONSTRAINT `FK_National_framework_Qualification_Qualification_ID` FOREIGN KEY (`Qualification_ID`) REFERENCES `Qualification` (`Qualification_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
