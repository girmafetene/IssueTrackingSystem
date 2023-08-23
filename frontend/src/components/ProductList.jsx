import React from "react";
import Card from "./Card";

const dummyProducts = [
  {
    title: "Product 1",
    description: "Description for Product 1",
    imageSrc: "/images/stock/photo-1.jpg",
  },
  {
    title: "Product 2",
    description: "Description for Product 2",
    imageSrc: "/images/stock/photo-2.jpg",
  },
  // Add more products here...
];

export default function ProductList() {
  return (
    <div className="flex flex-wrap justify-center gap-4">
      {dummyProducts.map((product, index) => (
        <Card
          key={index}
          title={product.title}
          description={product.description}
          imageSrc={product.imageSrc}
        />
      ))}
    </div>
  );
}
