// src/components/ProductDetails/ProductDetails.js
import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { getProductById } from '../../api-products/ProductsService';


const ProductDetails = () => {
  const [product, setProduct] = useState(null);
  const [imagePath, setImagePath] = useState(null);
  const [loading, setLoading] = useState(true);
  const { id } = useParams();


  const formatImagePath = (imagePath) => {
    const pathParts = imagePath.split(/[\\\/]/);
    const relativePathIndex = pathParts.indexOf('wwwroot');
    const relativePath = pathParts.slice(relativePathIndex).join('/');
    return `/${relativePath}`;
  };



  useEffect(() => {
    const fetchProduct = async () => {
      const fetchedProduct = await getProductById(id);
      setProduct(fetchedProduct);
      setLoading(false);
      setImagePath(fetchedProduct.image ? formatImagePath(fetchedProduct.image) : '')
    };

    fetchProduct();
  }, [id]);

  if (loading) {
    return <p>Loading product details...</p>;
  }

  return (
    <div>
      <h2>{product.name}</h2>
      <p>Size: {product.size}</p>
      <p>Price: ${product.price}</p>
      <p>Type: {product.type}</p>
      {product.ingredients && (
        <ol>
          {product.ingredients.map((ingredient) => (
            <li key={ingredient.id}>{ingredient.name}</li>
          ))}
        </ol>)}
      {<img src={"https://localhost:7031" + imagePath} alt={product.name} />}
      <p>Formated path{imagePath}</p>
      <p>Not formated path {product.image}</p>
    </div>
  );
};

export default ProductDetails;
