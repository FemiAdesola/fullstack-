[![FullStack](https://github.com/FemiAdesola/fs13-FullStack/actions/workflows/fullstack.yml/badge.svg?branch=main)](https://github.com/FemiAdesola/fs13-FullStack/actions)
# Fullstack Project

![TypeScript](https://img.shields.io/badge/TypeScript-v.4-green)
![SASS](https://img.shields.io/badge/SASS-v.4-hotpink)
![React](https://img.shields.io/badge/React-v.18-blue)
![Redux toolkit](https://img.shields.io/badge/Redux-v.1.9-brown)
![.NET Core](https://img.shields.io/badge/.NET%20Core-v.7-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-v.7-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-v.14-drakblue)

* Frontend: SASS, TypeScript, React, Redux Toolkit
* Backend: ASP .NET Core, Entity Framework Core, PostgreSQL 
    + Click [here](https://backend-femi.azurewebsites.net/index.html) or [this](https://femi-backend.azurewebsites.net/index.html) to see the RESTApi
    + Click [here](https://fullstackfrontend.netlify.app/) to see the frontend

## Table of content

- [Introduction](#introduction)
- [Technologies](#technologies)
- [Installation](#installation)
- [Project structure](#project-structure)
- [Getting started](#getting-started)

## Introduction
This is a full-stack project built with ASP .NET core for the backend and React Redux for the Frontend. For getting the full-stack project done, eCommerce was used as a way to illustrate the connection.
This project aims to understand the connection between the backend, database structure, and the frontend.
In addition, the backend was modeled first by designing the model from top to bottom and vice versa with ERD (Entity Relation Diagram), to get the relation needed, such as one-one, one-many, and many-many.

## Technologies
- Backend
    + PostgreSQL
    + ASP .NET Core, 
    + Entity Framework Core

- Frontend
    + RectJS
    + React bootsrap (for design and styling)
    + TypeScript
    + Redux
    + React hook userform
    + react-router-dom
    + Redux-persist
    + SASS/SCSS
    + web-vitals

## Installation

- Steps to perform the installation for the `Backend`
    + Register the database server with PostgreSQL
    + Check your local machine for .NET Core compatibility from microsoft webiste
    + Create an `appsettings.json` file in to main root like [example.json file](/Backend/example.json)
    + Perform these following commands
        1. dotnet restore
        2. dotnet build
        3. dotnet run
    + For database migration
        1. dotnet ef migrations  add [added new name here]
        2. dotnet ef database update
- Steps to perform the installation for the `Frontend`
    + Install all the dependencies
        1. Write `npm install` on your terminal 
    + Runs the app in the development mode.
        1.  Write `npm start` on your terminal 

## Project structure

```shell
backend
├── Authorization
│   └── UpdateUserPermission.cs
├── Controllers
│   ├── BaseApiController.cs
│   ├── CategoryController.cs
│   ├── CrudController.cs
│   ├── ErrorController.cs
│   ├── HttpErrorController.cs
│   ├── OrderController.cs
│   ├── OrderItemController.cs
│   ├── ProductController.cs
│   ├── ReviewController.cs
│   └── UserController.cs
├── DTOs
│   ├── AddOrderItemToOrderDTO.cs
│   ├── AddProductToOrderItemDTO.cs
│   ├── AddReviewToProductDTO.cs
│   ├── AddressDTO.cs
│   ├── BaseDTO.cs
│   ├── BaseReturnDTO.cs
│   ├── CategoryDTO.cs
│   ├── OrderDTO.cs
│   ├── OrderItemDTO.cs
│   ├── ProductDTO.cs
│   ├── ReviewDTO.cs
│   ├── UserSignInDTO.cs
│   ├── UserSignUpDTO.cs
│   └── UserUpdateDTO.cs
├── Database
│   ├── AppDbContext.cs
│   ├── AppDbContextSaveChangesInterceptor.cs
│   ├── CommonEntityExtension.cs
│   ├── DataStore.cs
│   └── IdentityConfigExtension.cs
├── Dockerfile
├── Errors
│   ├── ApiExceptionError.cs
│   ├── ApiResponseError.cs
│   └── ApiValidationError.cs
├── Extensions
│   ├── ApplicationServiceExtension.cs
│   ├── IdentityServiceExtensions.cs
│   └── SwaggerServiceExtension.cs
├── Helper
│   └── MappingProfile.cs
├── Middleware
│   ├── ErrorHandlerMiddleware.cs
│   └── LoggerMiddleware.cs
├── Migrations
│   ├── 20230324155045_InitiaMigration.Designer.cs
│   ├── 20230324155045_InitiaMigration.cs
│   └── AppDbContextModelSnapshot.cs
├── Models
│   ├── Address.cs
│   ├── BaseModel.cs
│   ├── Category.cs
│   ├── Order.cs
│   ├── OrderAndOrderItem.cs
│   ├── OrderItem.cs
│   ├── OrderItemProduct.cs
│   ├── Product.cs
│   ├── ProductBrand.cs
│   ├── Review.cs
│   ├── ReviewProduct.cs
│   └── User.cs
├── Program.cs
├── Properties
│   └── launchSettings.json
├── Services
│   ├── Implementations
│   │   ├── DbCategoryService.cs
│   │   ├── DbCrudService.cs
│   │   ├── DbOrderItemService.cs
│   │   ├── DbOrderService.cs
│   │   ├── DbProductService.cs
│   │   └── DbReviewService.cs
│   ├── Interface
│   │   ├── ICategoryService.cs
│   │   ├── ICrudService.cs
│   │   ├── IOrderItemService.cs
│   │   ├── IOrderService.cs
│   │   ├── IProductService.cs
│   │   └── IReviewService.cs
│   └── UserService
│       ├── IUserService.cs
│       ├── IUserTokenService.cs
│       ├── UserService.cs
│       └── UserTokenService.cs
├── backend.csproj
├── example.json
└── example.json

frontend
├── package.json
├── public
│   ├── _redirects
│   ├── favicon.ico
│   ├── index.html
│   ├── logo192.png
│   ├── logo512.png
│   ├── manifest.json
│   └── robots.txt
├── src
│   ├── App.css
│   ├── App.css.map
│   ├── App.tsx
│   ├── SCSS
│   │   ├── App.SCSS
│   │   └── features
│   │       ├── _common.SCSS
│   │       ├── _contact.SCSS
│   │       └── _footer.scss
│   ├── common
│   │   └── axiosIntsance.ts
│   ├── components
│   │   ├── Contact.tsx
│   │   ├── Footer.tsx
│   │   ├── Header.tsx
│   │   ├── Loader
│   │   │   └── Loader.tsx
│   │   ├── category
│   │   │   ├── Categories.tsx
│   │   │   ├── CategoryBoard.tsx
│   │   │   ├── CategoryCard.tsx
│   │   │   ├── CreateCategory.tsx
│   │   │   ├── SingleCategory.tsx
│   │   │   └── UpdateCategory.tsx
│   │   ├── order
│   │   │   └── OrderDetails.tsx
│   │   ├── orderItem
│   │   │   ├── Checkout.tsx
│   │   │   ├── OrderItem.tsx
│   │   │   └── ShippingAddress.tsx
│   │   ├── product
│   │   │   ├── CreateProduct.tsx
│   │   │   ├── ProductBoard.tsx
│   │   │   ├── ProductCard.tsx
│   │   │   ├── Products.tsx
│   │   │   ├── Review.tsx
│   │   │   ├── SingleProduct.tsx
│   │   │   └── UpdateProduct.tsx
│   │   └── user
│   │       ├── Login.tsx
│   │       ├── Profile.tsx
│   │       └── SignUp.tsx
│   ├── features
│   │   ├── BoardWrapper.tsx
│   │   ├── FooterBottom.tsx
│   │   ├── FormContainer.tsx
│   │   ├── HeaderTop.tsx
│   │   ├── HomeCarousel.tsx
│   │   ├── HomeMeta.tsx
│   │   └── Rating.tsx
│   ├── formValidation
│   │   ├── categorySchema.ts
│   │   ├── productSchema.ts
│   │   └── signUpSchema.ts
│   ├── hooks
│   │   └── reduxHooks.ts
│   ├── index.css
│   ├── index.tsx
│   ├── logo.svg
│   ├── pages
│   │   ├── Home.tsx
│   │   └── Layout.tsx
│   ├── react-app-env.d.ts
│   ├── redux
│   │   ├── method
│   │   │   ├── categoryMethod.ts
│   │   │   ├── orderMethod.ts
│   │   │   ├── productMethod.ts
│   │   │   └── userMethod.ts
│   │   ├── reducers
│   │   │   ├── categoryReducer.ts
│   │   │   ├── orderItemReducer.ts
│   │   │   ├── orderReducer.ts
│   │   │   ├── productReducer.ts
│   │   │   └── userReducer.ts
│   │   └── store.ts
│   ├── reportWebVitals.ts
│   ├── setupTests.ts
│   └── types
│       ├── boardWrapper.ts
│       ├── category.ts
│       ├── homeLayout.ts
│       ├── order.ts
│       ├── orderItem.ts
│       ├── product.ts
│       ├── review.ts
│       └── user.ts
└── tsconfig.json
```

## Getting started

- Users have to generate a token and insert it before they could be able to get total access to all the functionality.


### Frontend product page

![Frontend](/img/Frontend.png)

### Frontend single product page

![SinglePage](/img/Singleproduct.png)

### Backend with azurewebsites for Category and Order endpoint

![Backend1](/img/Backend1.png)

### Backend with azurewebsites for Ordertem. product and review endpoint

![Backend2](/img/Backend1.png)

### Backend with azurewebsites for user endpoint

![User](/img/user.png)

### Example for query endpoint 

![Query](/img/Examplequery.png)