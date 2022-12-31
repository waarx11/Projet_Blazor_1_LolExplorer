---
Title: LolExplorer
author: Rami Khedair, Nathan Verdier
---

# Tutoriel des fonctionnalités disponible
vous lancer le projet depuis la branche master.
## Visialisation
Tous les éléments sont affichés dans une liste, ou nous pouvons cliquer sur un élément pour obtenir plus d'informations sur celui-ci. Cela signifie que chaque élément de la liste est accompagné d'un lien qui nous permet de voir plus de détails sur l'élément en question. Cela peut être utile si nous voulons en savoir plus sur un élément spécifique, par exemple pour voir des images supplémentaires ou des informations détaillées sur l'élément.

## Action Sur La Liste
Nous avons la possibilité de faire trois opérations différentes sur les éléments de la liste : ajouter de nouveaux éléments, supprimer des éléments existants et éditer des éléments existants.

**L'ajout** d'un nouvel élément consiste à créer un nouvel élément et à l'ajouter dans la liste. Cela peut être utile si nous voulons ajouter de nouvelles informations ou de nouveaux éléments à la liste.

**La suppression** d'un élément consiste à supprimer un élément existant de la liste. Cela peut être utile si nous voulons retirer de l'information obsolète ou inutile de la liste.

**L'édition** d'un élément consiste à modifier les informations d'un élément existant. Cela peut être utile si nous voulons mettre à jour des informations ou corriger des erreurs dans l'élément.

## Action Exterieur
### Crafting : 
Nous avons la possibilité de créer (craft) de nouveaux items en utilisant jusqu'à trois items existants. La recette pour créer un item spécifique est affichée sur la page de visualisation de cet item, dans la section "De" ou "From". Les éléments de crafting sont ceux qui se trouvent dans notre inventaire.

En d'autres termes, pour créer un nouvel item, nous devons avoir accès à la recette de cet item et à au plus trois items existants qui nous permettront de créer le nouvel item. La recette nous indiquera quels items nous devons utiliser. Nous devrons alors sélectionner ces items dans notre inventaire et les utiliser pour créer le nouvel item.

### Inventaire: 
nous avons un inventaire dans lequel nous stockons les éléments que nous avons collectés et qui nous serviront à créer de nouveaux items. Nous ne pouvons pas avoir deux fois le même item dans notre inventaire, ce qui signifie que chaque item est unique et ne peut être dupliqué.

Notre inventaire est organisé en cases, comme dans le jeu Minecraft. Chaque case est un emplacement où nous pouvons stocker un item. Par exemple, la case 1 n'est pas la même que la case 5, et nous pouvons donc changer la position d'un item dans notre inventaire au besoin en le déplaçant d'une case à une autre. Cependant, dans l'interface de crafting, l'emplacement des items dans l'inventaire n'est pas affiché, mais cette information est bien prise en compte dans le code. Cela a pour but de simplifier l'affichage à l'utilisateur et de rendre plus facile l'utilisation de l'interface de crafting.

### Mouvement des items: 
nous pouvons déplacer les items en utilisant la fonction de "drag and drop", c'est-à-dire en cliquant sur un item et en le faisant glisser vers un autre emplacement. Si nous faisons glisser un item vers un espace vide, cela le supprimera de sa case d'origine, que cette case soit dans l'inventaire ou dans la recette de crafting.
### Creation de log
on peut créer un log dans le but de pouvoir debuger :=)

## Solution De Projet (Comment ça marche)
Ce depôt a une solution qui comprend deux projets différents : le projet Blazor et le projet API. Le projet Blazor est l'application Blazor elle-même, tandis que le projet API est une application qui expose des services web (API) que le projet Blazor peut utiliser pour accéder à des données ou effectuer des actions.

Le projet Blazor a besoin de l'API pour fonctionner car toutes les données sont stockées dans l'API et non dans le projet Blazor. Le projet Blazor peut utiliser le stockage local (local storage) pour stocker certaines données, mais il ne peut pas effectuer d'actions externes sans l'aide de l'API. Pour cette raison, il est nécessaire de lancer les deux projets ensemble afin que le projet Blazor puisse fonctionner correctement.

Pour lancer les deux projets ensemble, vous pouvez utiliser la fonction "Debug" de Visual Studio en sélectionnant les deux projets comme projets de démarrage.

### Code-Level Illustration

Dans ce projet, nous avons utilisé plusieurs patrons de conception tels que la factory et le singloton afin de structurer notre code de manière efficace et adaptée aux besoins de notre application.
Au début de ce projet, nous avons effectué une recherche pour trouver un fichier JSON qui contient des informations sur nos éléments provenant du site officiel de jeux League of Legends.
Grâce à ce fichier, nous avons pu sélectionner les attributs dont nous avions besoin et créer un diagramme de classe pour la classe métier et des sketches et des diagrammes. Pour gérer les modifications et les ajouts d'éléments, nous avons créé une classe modèle et une classe factory pour gérer la conversion entre les classes modèle et métier. Bien sûr, des composants graphiques ont également été développés pour permettre la visualisation des données, que nous aborderons ultérieurement.

Pour la sérialisation et la désérialisation, nous avons repris le prjet API proposée dans le TP en la modifiant pour qu'elle s'adapte à notre utilisation et à nos classes. L'API comprend les requêtes DELETE, PUT, GET et POST. 
Elle contient également trois fichiers JSON :
**apiLolItem.json** qui est le fichier de backup contenant toutes les informations (jamais utilisé dans l'API).
**inventory.json** qui contient les éléments de l'inventaire de l'utilisateur
**items.json** qui contient la liste d'éléments de l'utilisateur.

En plus, nous avons développé un autre service au début du projet qui utilisait le local storage de l'utilisateur pour stocker les informations. Cependant, ce service était limité en termes d'espace de stockage et, étant donné que notre projet comprend plus de 200 éléments, nous avons dû enregistrer les images dans une base de données. Ce service est devenu plus compatible avec notre projet au fil du temps.

J'ai effectué quelques manipulations de données dans le fichier JSON car les données que j'ai récupérées n'étaient pas tout à fait compatibles avec notre projet. Par exemple, les propriétés ID, from et into étaient des chaînes de caractères alors qu'elles devaient être des entiers dans notre projet. De plus, en utilisant le local storage, nous ne pouvions stocker que peu d'éléments, il fallait donc en sélectionner 20 en prenant en compte les recettes. J'ai effectué toutes ces modifications de fichier en utilisant JavaScript et j'ai laissé les fichiers dans le dossier DOC/JavaScript pour que vous puissiez y jeter un coup d'œil ;) ).

Pour la mise en œuvre de la traduction de notre projet, nous avons utilisé le contrôleur CultureController qui s'occupe de définir la langue actuelle et de traduire les vues en fonction des ressources que nous avons créées.

Le chemin standard pour les actions sur le site est le suivant : au début, la page est chargée en fonction de la langue choisie. Ensuite, une demande est effectuée à l'API à partir de notre IDataService qui est appelé dans les vues et qui obtient une seule instance de IDataService grâce au concept de singloton et l'injecte dans la page, ce qui permet de afficher son contenu. Ensuite, toutes les autres actions sont traitées de la même manière, en communiquant toujours avec l'API.

Pour les vues, il y a les composants normaux qui se trouvent dans le dossier Pages et il y a également des composants plus complexes qui se trouvent dans le dossier Components. Nous allons expliquer chaque composant et ses fonctionnalités :
#### Crafting.razor : 

Ce composant permet de crafter des éléments et contient plusieurs instances du composant CraftingItem. Il reçoit en paramètre une liste d'éléments qui est doit l'afficher(dans notre cas c'est linventaire), ce qui permet de facilement changer le contenu de l'inventaire depuis le composant parent (par exemple, au début, il affiche la liste complète des éléments, mais lorsque nous avons développé la partie inventaire, il a suffi de changer dans le composant parent CraftingItem le contenu de sa liste en appelant une méthode différente de IDataService). Il contient également le composant Inventory pour afficher le contenu de la liste reçue en paramètre.

#### CraftingItem.razor : 
Ce composant est responsable de la fonctionnalité de "drag and drop" et communique avec le composant parent qui doit être de type Crafting. Il utilise le composant ItemDisplay pour afficher l'élément.

#### Inventory.razor : 
Ce composant est responsable de l'affichage d'une liste d'éléments en utilisant le composant CraftingItem. Il y a plusieurs cas d'utilisation :
Avoir une barre de recherche qui cherche par nom et par tags dans les éléments, 

Utiliser un datagrid pour afficher la liste (suivant la demande de Mockup sur le site de TP), utiliser une barre de recherche en utilisant la fonctionnalité FILTERABLE mais malheureusement, nous perdons la possibilité de chercher par tags (avant que je sois au courant de cette fonctionnalité, j'ai mis en place une barre de recherche dans le composant qui soit compatible avec le datagrid, ce qui a pris du temps pour mettre en place, c'est pour ça que je le mentionne :) ).

Affichage de la liste normal qui est utilisé dans la page de Crafting..    

#### ItemDisplay.razor :
Ce composant est responsable de l'affichage d'un élément sur tout le site, ce qui permet d'avoir un affichage homogène. En cliquant dessus, nous sommes redirigés vers sa page d'informations.

Il y a un dernier composant, mais il n'est pas dans le dossier Pages :

#### InventoryItem.razor :
Ce composant hérite du composant Crafting pour pouvoir utiliser le composant CraftingItem, ce qui évite de recréer un composant InventoryItem. Cependant, un point d'amélioration pour mon site serait de créer une classe mère abstraite dont les classes InventoryItem et Crafting hériteraient, plutôt que de faire un héritage direct entre InventoryItem et Crafting. Cependant, je n'ai pas pu mettre cela en place en raison d'un problème du delai :'( .
