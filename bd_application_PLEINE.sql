-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Jeu 19 Mai 2016 à 16:37
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `bd_application`
--

-- --------------------------------------------------------

--
-- Structure de la table `details_recette`
--

CREATE TABLE IF NOT EXISTS `details_recette` (
  `ID_Recettes` int(11) NOT NULL,
  `ID_Produit` int(11) NOT NULL,
  `quantite` double NOT NULL,
  KEY `details_recette_ibfk_2` (`ID_Produit`),
  KEY `details_recette_ibfk_1` (`ID_Recettes`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `details_recette`
--

INSERT INTO `details_recette` (`ID_Recettes`, `ID_Produit`, `quantite`) VALUES
(100, 1, 400),
(100, 25, 250),
(100, 40, 1),
(100, 41, 5),
(100, 42, 5),
(100, 52, 100),
(100, 54, 1),
(101, 1, 1000),
(101, 24, 250),
(101, 10, 100),
(102, 40, 2),
(102, 17, 40),
(102, 10, 5),
(102, 42, 5),
(102, 27, 480),
(102, 45, 120),
(102, 53, 10),
(103, 28, 1),
(103, 40, 1),
(103, 30, 10),
(103, 41, 10),
(103, 43, 5),
(103, 1, 250),
(103, 38, 150),
(103, 19, 50),
(103, 52, 50),
(103, 53, 10),
(104, 47, 250),
(104, 44, 250),
(104, 48, 25),
(104, 46, 25),
(104, 30, 30),
(106, 19, 15),
(106, 53, 10),
(106, 42, 5),
(106, 56, 20),
(106, 57, 250),
(108, 40, 2),
(108, 12, 10),
(108, 42, 5),
(108, 53, 10),
(108, 16, 1),
(108, 21, 100),
(108, 19, 50),
(108, 56, 25),
(108, 58, 2),
(110, 40, 1),
(110, 18, 250),
(110, 7, 1),
(110, 1, 1),
(110, 37, 25),
(110, 24, 25),
(110, 57, 25),
(110, 52, 75);

-- --------------------------------------------------------

--
-- Structure de la table `evenements`
--

CREATE TABLE IF NOT EXISTS `evenements` (
  `date` date NOT NULL,
  `evenement` varchar(200) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `fournisseurs`
--

CREATE TABLE IF NOT EXISTS `fournisseurs` (
  `id_fournisseur` int(11) NOT NULL AUTO_INCREMENT,
  `nom_fournisseur` varchar(100) NOT NULL,
  `adresse_fournisseur` varchar(150) DEFAULT NULL,
  `ville_fournisseur` varchar(50) DEFAULT NULL,
  `code_postal` char(6) DEFAULT NULL,
  `tel_fournisseur` char(13) DEFAULT NULL,
  `no_poste` varchar(15) DEFAULT NULL,
  `personne_contact` varchar(100) DEFAULT NULL,
  `notes` text,
  PRIMARY KEY (`id_fournisseur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `inventaire`
--

CREATE TABLE IF NOT EXISTS `inventaire` (
  `ID_produit` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(100) NOT NULL,
  `Quantite` double NOT NULL,
  `Format` double NOT NULL,
  `datePeremption` date DEFAULT NULL,
  `Note` text,
  `noProduit` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID_produit`),
  KEY `fk_inventaire_noProduit` (`noProduit`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Contenu de la table `inventaire`
--

INSERT INTO `inventaire` (`ID_produit`, `Nom`, `Quantite`, `Format`, `datePeremption`, `Note`, `noProduit`) VALUES
(2, 'Patate du maroc', 8, 10, '2016-07-01', 'a cuire longtemps', 1),
(3, 'Ails frais Métro', 15, 25, NULL, 'frais', 40),
(4, 'Patate yukon gold', 3, 10, NULL, '', 1),
(5, 'Farine rive roses', 2, 1000, NULL, '', 5),
(6, 'Ananas du IGA', 2, 1, '2016-06-23', '', 15),
(7, 'Oeufs moyen', 4, 12, NULL, '', 9);

-- --------------------------------------------------------

--
-- Structure de la table `produits`
--

CREATE TABLE IF NOT EXISTS `produits` (
  `ID_produit` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `unite_mesure` varchar(20) NOT NULL,
  `Categorie` varchar(75) DEFAULT NULL,
  PRIMARY KEY (`ID_produit`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=60 ;

--
-- Contenu de la table `produits`
--

INSERT INTO `produits` (`ID_produit`, `nom`, `unite_mesure`, `Categorie`) VALUES
(1, 'Patate', 'unité', 'Légume'),
(2, 'Maïs', 'unité', 'Légume'),
(3, 'Pastèque', 'unité', 'Fruit'),
(5, 'Farine', 'g', 'Produit céréalier'),
(7, 'Tomates', 'unité', 'Fruit'),
(9, 'Oeufs', 'unité', 'Viande et substitut'),
(10, 'Bacon', 'g', 'Viande et substitut'),
(11, 'Artichaut', 'unité', 'Légume'),
(12, 'Sauce soja', 'ml', 'Sauce'),
(15, 'Ananas', 'unité', 'Fruits'),
(16, 'Citron', 'unité', 'Fruits'),
(17, 'Tomate en canne', 'ml', 'Conserve'),
(18, 'Boeuf haché', 'g', 'Viande et substitut'),
(19, 'Champigons', 'g', 'Légume'),
(20, 'Haricots verts', 'g', 'Légume'),
(21, 'Riz', 'g', 'Produit céréalier'),
(22, 'Pain', 'unité', 'Produit céréalier'),
(23, 'Pain brun', 'unité', 'Produit céréalier'),
(24, 'Fromage Chedar', 'g', 'Produit Laitier'),
(25, 'Lait', 'ml', 'Produit Laitier'),
(26, 'Steak de boeuf', 'g', 'Viande et substitut'),
(27, 'Spaghetti', 'g', 'Produit céréalier'),
(28, 'Poulet', 'unité', 'Viande et substitut'),
(30, 'Beurre', 'g', 'Produit Laitier'),
(31, 'Brocoli', 'g', 'Légume'),
(32, 'Chou', 'unité', 'Légume'),
(33, 'Cuisses de grenouille', 'g', 'Viande et substitut'),
(34, 'Jambon cru', 'g', 'Viande et substitut'),
(35, 'Tofu', 'g', 'Viande et substitut'),
(36, 'Wazabi', 'ml', 'Sauce'),
(37, 'Ketchup', 'ml', 'Sauce'),
(38, 'Épinard', 'g', 'Légume'),
(39, 'Brochet', 'unité', 'Viande et substitut'),
(40, 'Ail', 'unité', 'Légume'),
(41, 'Sel', 'g', 'Épices'),
(42, 'Poivre', 'g', 'Épices'),
(43, 'Tabasco', 'ml', 'Sauce'),
(44, 'Dattes', 'g', 'Fruit'),
(45, 'Crevettes', 'g', 'Viande et substitut'),
(46, 'Cassonade', 'g', 'Produit sucrant'),
(47, 'Avoine', 'g', 'Produit céréalier'),
(48, 'Eau', 'ml', 'Eau'),
(52, 'Oignon', 'g', 'Légume'),
(53, 'Huile d''olive', 'ml', 'Sauce'),
(54, 'Morue', 'unité', 'Viande et substitut'),
(56, 'Poivron coupé', 'g', 'Légume'),
(57, 'Laitue', 'g', 'Légume'),
(58, 'Saumon', 'unité', 'Viande et substitut'),
(59, 'Pain Hamburger', 'unité', 'Produit céréalier');

-- --------------------------------------------------------

--
-- Structure de la table `recettes`
--

CREATE TABLE IF NOT EXISTS `recettes` (
  `ID_recettes` int(11) NOT NULL AUTO_INCREMENT,
  `nomRecette` varchar(150) NOT NULL,
  `tempsPreparation` varchar(30) DEFAULT NULL,
  `tempsCuisson` varchar(30) NOT NULL,
  `nbPortions` int(11) NOT NULL,
  `temperature` int(11) NOT NULL,
  `etapes` text NOT NULL,
  `image` varchar(500) NOT NULL,
  PRIMARY KEY (`ID_recettes`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=111 ;

--
-- Contenu de la table `recettes`
--

INSERT INTO `recettes` (`ID_recettes`, `nomRecette`, `tempsPreparation`, `tempsCuisson`, `nbPortions`, `temperature`, `etapes`, `image`) VALUES
(100, 'Morue et pommes de terre', '1 heure', '30 min', 1, 375, 'Préchauffer le four à 175ºC/350ºF. Éplucher les pommes de terre et les trancher finement (6-7 mm); mettre les tranches dans une poêle anti-adhésive juste assez grande pour les contenir. Verser le lait pour les recouvrir. Ajouter la feuille de laurier, l''ail pressé et saler généreusement. Porter à ébullition sur feu moyen, en remuant de temps à autre afin que les pommes de terre ne collent pas au fond de la poêle. Baisser le feu et cuire 15-20 min en remuant de temps à autre, jusqu''à ce que les pommes de terre soient tendres sans se défaire.\nVerser les pommes de terre et le liquide dans un plat à gratin. Couvrir de crème, saupoudrer de noix muscade et poivre moulu. Cuire au centre du four environ 30 min jusqu''à ce que le dessus des pommes de terre soit bien doré et croustillant.\nPendant la cuisson des pommes de terre, couper l''oignon en minces rondelles. Chauffer le beurre et l''huile dans un poêlon et y faire revenir l''oignon 4-5 min jusqu''à ce que translucide. Réserver. \nBien éponger le filet de morue et le couper en portions. Sortir le plat du four, soulever les pommes de terre et glisser les morceaux de morue en dessous. Remettre le tout au four et cuire encore 5-10 min, selon l''épaisseur du poisson. Vérifier la cuisson du poisson avec une fourchette. Déposer l''oignon sur le dessus et servir. \n\n', '\\\\etudiants.cegeptr.qc.ca\\Etudiants\\1433095\\Mes documents\\Visual Studio 2015\\Projects\\Kek\\Kek\\bin\\Debug\\Images\\JLC1.JLC'),
(101, 'Pommes de terre bacon', '45 min', '30 min ', 8, 450, '1 ) Faire des fentes sur les patates\n\n2 ) Insérer le bacon précuit\n\n3 ) Mettre le fromage\n\n4 ) Mettre au four\n', '\\\\etudiants.cegeptr.qc.ca\\Etudiants\\1433095\\Mes documents\\Visual Studio 2015\\Projects\\Kek\\Kek\\bin\\Debug\\Images\\JLC100.JLC'),
(102, 'Pâtes aux crevettes', '45 min', '19 min ', 2, 0, 'Porter à ébullition une grande casserole d’eau salée. Y plonger les pâtes et les laisser cuire pendant 8 à 10 minutes ou jusqu’à ce qu’elles soient al dente. Égoutter.\nDans une poêle, faire fondre le beurre à feu moyen. Ajouter le vin, le fromage, l’ail, le persil, ainsi que le sel et le poivre. Faire mijoter à feu doux pendant 3 à 5 minutes en remuant fréquemment.\nAugmenter le feu à moyen-vif et ajouter les crevettes. Faire revenir pendant 3 à 4 minutes ou jusqu’à ce qu’elles commencent à devenir roses. Ne pas trop les cuire.\nDiviser les pâtes en portions individuelles et verser les crevettes et la sauce. Garnir de parmesan râpé et de persil frais.\n', '\\\\etudiants.cegeptr.qc.ca\\Etudiants\\1433095\\Mes documents\\Visual Studio 2015\\Projects\\Kek\\Kek\\bin\\Debug\\Images\\JLC101.JLC'),
(103, 'Poulet au four', '4 heures', '3 heures', 6, 400, 'Placer la grille au centre du four. Préchauffer le four à 200 °C (400 °F).\n\nDéposer le poulet sur une assiette. Saupoudrer le sel sur la peau et frotter en insistant sur les poitrines et les cuisses. Laisser macérer 15 minutes. Badigeonner avec l’huile. Dans un petit bol, mélanger les oignons verts et les herbes. Répartir sur le poulet. Déposer dans une cocotte ou un plat de cuisson. Poivrer.\nCuire au four de 1 h 15 à 1 h 30 ou jusqu’à ce qu’un thermomètre inséré dans la cuisse, sans toucher l’os, indique 82 °C (180 °F).\n', '\\\\etudiants.cegeptr.qc.ca\\Etudiants\\1433095\\Mes documents\\Visual Studio 2015\\Projects\\Kek\\Kek\\bin\\Debug\\Images\\JLC102.JLC'),
(104, 'Carrés aux dattes', '2 heures', '1 heure', 5, 350, 'Placer la grille au centre du four. Préchauffer le four à 180 °C (350 °F). Tapisser un plat de cuisson carré de 20 cm (8 po) d’une bande de papier parchemin en le laissant dépasser sur deux côtés. Beurrer les deux autres côtés.\nDans une casserole, porter à ébullition les dattes, l’eau, le jus de citron et la cassonade. Ajouter le bicarbonate et laisser mijoter environ 5 minutes en remuant constamment à la cuillère de bois jusqu’à ce que les dattes soient réduites en purée. Laisser tiédir.\nDans un bol, mélanger les flocons d’avoine, la farine, la cassonade et la poudre à pâte. Ajouter le beurre et bien mélanger. \nRépartir la moitié du croustillant dans le plat de cuisson et presser fermement. Y étaler le mélange de dattes. Couvrir avec le reste du croustillant et presser légèrement. Cuire au four environ 55 minutes ou jusqu’à ce que le croustillant soit bien doré. Laisser refroidir sur une grille environ 4 heures ou toute une nuit. Démouler et couper en 9 à 16 carrés.\n', '\\\\etudiants.cegeptr.qc.ca\\Etudiants\\1433095\\Mes documents\\Visual Studio 2015\\Projects\\Kek\\Kek\\bin\\Debug\\Images\\JLC103.JLC'),
(106, 'Salade fraicheur', '15 min', '0', 1, 0, 'Mélanger le tout dans un bol, puis ajouter l''huile d''olive.', '\\\\etudiants.cegeptr.qc.ca\\Etudiants\\1433095\\Mes documents\\Visual Studio 2015\\Projects\\Kek\\Kek\\bin\\Debug\\Images\\JLC104.JLC'),
(108, 'Saumon et riz', '2 heures', '1 heures', 4, 350, 'Préchauffer le four à 200 °C (400 °F). Dans un plat peu profond allant au four, répartir les légumes émincés. Y déposer les filets de saumon et les arroser de jus de citron. Parsemer d''aneth frais. Assaisonner au goût. Cuire de 8 à 10 minutes ou jusqu''à ce que la chair des filets de poisson se défasse facilement à la fourchette. Accompagner de riz brun.\n', '\\\\etudiants.cegeptr.qc.ca\\Etudiants\\1433095\\Mes documents\\Visual Studio 2015\\Projects\\Kek\\Kek\\bin\\Debug\\Images\\JLC106.JLC'),
(110, 'Hamburger et frites maison', '50 min', '15 min', 3, 0, 'ÉTAPE 1\nFaire revenir les oignons dans l''huile.\n\nÉTAPE 2\nÉmietter le pain et enlever le surplus de lait.\n\nÉTAPE 3\n\nDans un bol, mélanger le veau et le boeuf hachés avec tous les ingrédients.\n\nÉTAPE 4\n\nFaire des boulettes et faire cuire\n                                       ', '\\\\etudiants.cegeptr.qc.ca\\Etudiants\\1433095\\Mes documents\\Visual Studio 2015\\Projects\\Kek\\Kek\\bin\\Debug\\Images\\JLC108.JLC');

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `details_recette`
--
ALTER TABLE `details_recette`
  ADD CONSTRAINT `details_recette_ibfk_2` FOREIGN KEY (`ID_Produit`) REFERENCES `produits` (`ID_produit`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `details_recette_ibfk_1` FOREIGN KEY (`ID_Recettes`) REFERENCES `recettes` (`ID_recettes`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `inventaire`
--
ALTER TABLE `inventaire`
  ADD CONSTRAINT `fk_inventaire_noProduit` FOREIGN KEY (`noProduit`) REFERENCES `produits` (`ID_produit`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
