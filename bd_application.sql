-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Mar 13 Septembre 2016 à 18:47
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
-- Structure de la table `categories`
--

CREATE TABLE IF NOT EXISTS `categories` (
  `ID_Categorie` int(11) NOT NULL AUTO_INCREMENT,
  `Nom_Categorie` varchar(100) NOT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`ID_Categorie`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `commandes`
--

CREATE TABLE IF NOT EXISTS `commandes` (
  `ID_Commande` int(11) NOT NULL AUTO_INCREMENT,
  `Date_Commande` date NOT NULL,
  `Total` double NOT NULL,
  `Produits_Fournisseurs` int(12) NOT NULL,
  `No_Reference` varchar(25) DEFAULT NULL,
  `Note` text,
  PRIMARY KEY (`ID_Commande`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `details_commande`
--

CREATE TABLE IF NOT EXISTS `details_commande` (
  `ID_COMMANDE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `details_recette`
--

CREATE TABLE IF NOT EXISTS `details_recette` (
  `ID_Produit` int(11) NOT NULL,
  `ID_Recette` int(11) NOT NULL,
  `Quantite` double NOT NULL,
  `Unite_Mesure` varchar(35) NOT NULL,
  KEY `ID_Produit` (`ID_Produit`),
  KEY `ID_Recette` (`ID_Recette`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `evenements`
--

CREATE TABLE IF NOT EXISTS `evenements` (
  `id_evenement` int(11) NOT NULL AUTO_INCREMENT,
  `Nom_Evenement` varchar(250) NOT NULL,
  `Date_Evenement` date NOT NULL,
  PRIMARY KEY (`id_evenement`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `fournisseurs`
--

CREATE TABLE IF NOT EXISTS `fournisseurs` (
  `ID_Fournisseur` int(11) NOT NULL AUTO_INCREMENT,
  `Nom_Fournisseur` varchar(50) NOT NULL,
  `Note` text,
  `Adresse` varchar(75) DEFAULT NULL,
  `Ville` varchar(75) DEFAULT NULL,
  `Province` varchar(30) DEFAULT NULL,
  `Code_Postal` char(7) DEFAULT NULL,
  `Telephone` char(14) DEFAULT NULL,
  `Poste` varchar(30) DEFAULT NULL,
  `Cell` char(14) DEFAULT NULL,
  `Fax` char(14) DEFAULT NULL,
  `Nom_Contact` varchar(75) DEFAULT NULL,
  `Jour_Commande` varchar(60) DEFAULT NULL,
  `Jour_Livraison` varchar(60) DEFAULT NULL,
  `Delai_Commande` int(3) DEFAULT NULL,
  `Cout_Minimum` double DEFAULT NULL,
  `Frais_Livraison` double DEFAULT NULL,
  `Courriel` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID_Fournisseur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `inventaire`
--

CREATE TABLE IF NOT EXISTS `inventaire` (
  `ID_Inventaire` int(11) NOT NULL AUTO_INCREMENT,
  `Produit` int(11) NOT NULL,
  `Prix` double DEFAULT NULL,
  `Format` varchar(10) DEFAULT NULL,
  `Peremption` date DEFAULT NULL,
  `Local` char(7) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Date_Reception` date DEFAULT NULL,
  PRIMARY KEY (`ID_Inventaire`),
  KEY `Produit` (`Produit`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `produits`
--

CREATE TABLE IF NOT EXISTS `produits` (
  `ID_Produit` int(11) NOT NULL AUTO_INCREMENT,
  `Nom_Produit` varchar(100) NOT NULL,
  `Categorie` int(11) NOT NULL,
  `Duree_Vie` int(4) DEFAULT NULL,
  `Taxable_Federal` tinyint(1) NOT NULL,
  `Taxable_Provincial` tinyint(1) NOT NULL,
  `Code_UCP` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_Produit`),
  KEY `Categorie` (`Categorie`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Structure de la table `produits_fournisseurs`
--

CREATE TABLE IF NOT EXISTS `produits_fournisseurs` (
  `ID_Produit` int(11) NOT NULL,
  `ID_Fournisseur` int(11) NOT NULL,
  `Prix` double DEFAULT NULL,
  `Format_Achat` varchar(50) DEFAULT NULL,
  KEY `ID_Produit` (`ID_Produit`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `recettes`
--

CREATE TABLE IF NOT EXISTS `recettes` (
  `ID_Recette` int(11) NOT NULL AUTO_INCREMENT,
  `Nom` varchar(50) NOT NULL,
  `Temps_Preparation` double DEFAULT NULL,
  `Temps_Cuisson` double DEFAULT NULL,
  `Nb_Portions` varchar(15) DEFAULT NULL,
  `Taille_Portion` varchar(15) DEFAULT NULL,
  `Unite_Mesure` varchar(15) DEFAULT NULL,
  `Temperature` varchar(10) DEFAULT NULL,
  `Temps_Refroidissement` double DEFAULT NULL,
  `Etapes` text,
  `Image` varchar(255) DEFAULT NULL,
  `Remarque` text,
  `Allergies` varchar(250) DEFAULT NULL,
  `Duree_Conservation` int(4) DEFAULT NULL,
  `Categorie` varchar(50) NOT NULL,
  `congelable` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`ID_Recette`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `details_recette`
--
ALTER TABLE `details_recette`
  ADD CONSTRAINT `details_recette_ibfk_2` FOREIGN KEY (`ID_Recette`) REFERENCES `recettes` (`ID_Recette`),
  ADD CONSTRAINT `details_recette_ibfk_1` FOREIGN KEY (`ID_Produit`) REFERENCES `produits` (`ID_Produit`);

--
-- Contraintes pour la table `inventaire`
--
ALTER TABLE `inventaire`
  ADD CONSTRAINT `inventaire_ibfk_1` FOREIGN KEY (`Produit`) REFERENCES `produits` (`ID_Produit`);

--
-- Contraintes pour la table `produits`
--
ALTER TABLE `produits`
  ADD CONSTRAINT `produits_ibfk_1` FOREIGN KEY (`Categorie`) REFERENCES `categories` (`ID_Categorie`);

--
-- Contraintes pour la table `produits_fournisseurs`
--
ALTER TABLE `produits_fournisseurs`
  ADD CONSTRAINT `produits_fournisseurs_ibfk_1` FOREIGN KEY (`ID_Produit`) REFERENCES `produits` (`ID_Produit`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
