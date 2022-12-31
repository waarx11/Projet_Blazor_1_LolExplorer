---
Title: LolExplorer
author: Rami Khedair, Nathan Verdier
---

# Tutoriel des fonctionnalités disponible
vous lancer le projet depuis la branche master.
## Visialisation
Tous les éléments sont affichés dans une liste et que nous pouvons cliquer sur un élément pour obtenir plus d'informations sur celui-ci. Cela signifie que chaque élément de la liste est accompagné d'un lien qui nous permet de voir plus de détails sur l'élément en question. Cela peut être utile si nous voulons en savoir plus sur un élément spécifique, par exemple pour voir des images supplémentaires ou des informations détaillées sur l'élément.

## Action Sur La Liste
Nous avons la possibilité de faire trois opérations différentes sur les éléments de la liste : ajouter de nouveaux éléments, supprimer des éléments existants et éditer des éléments existants.

**L'ajout** d'un nouvel élément consiste à créer un nouvel élément et à l'ajouter à la liste. Cela peut être utile si nous voulons ajouter de nouvelles informations ou de nouveaux éléments à la liste.

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
## Solution De Projet 
Ce depôt a une solution qui comprend deux projets différents : le projet Blazor et le projet API. Le projet Blazor est l'application Blazor elle-même, tandis que le projet API est une application qui expose des services web (API) que le projet Blazor peut utiliser pour accéder à des données ou effectuer des actions.

Le projet Blazor a besoin de l'API pour fonctionner car toutes les données sont stockées dans l'API et non dans le projet Blazor. Le projet Blazor peut utiliser le stockage local (local storage) pour stocker certaines données, mais il ne peut pas effectuer d'actions externes sans l'aide de l'API. Pour cette raison, il est nécessaire de lancer les deux projets ensemble afin que le projet Blazor puisse fonctionner correctement.

Pour lancer les deux projets ensemble, vous pouvez utiliser la fonction "Debug" de Visual Studio en sélectionnant les deux projets comme projets de démarrage.