```shell
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

```shell
mkdir backendtest
cd backendtest
dotnet new sln
ls
mv mv ../Backend/ .
ls

mkdir backend.Test
cd backend.Test/
dotnet new xunit
ls
cd ..
ls
code-insiders .
 

```
