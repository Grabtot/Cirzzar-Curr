// src/components/ProductDetails/ProductDetails.js
import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { getProductById } from '../../api-products/ProductsService';


const ProductDetails = () => {
  const [product, setProduct] = useState(null);
  const [imagePath, setImagePath] = useState(null);
  const [loading, setLoading] = useState(true);
  const { id } = useParams();


  useEffect(() => {
    const fetchProduct = async () => {
      const fetchedProduct = await getProductById(id);
      setProduct(fetchedProduct);
      setLoading(false);
      setImagePath(fetchedProduct.image);
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
        <p>Ingredients:
          <ol>
            {product.ingredients.map((ingredient) => (
              <li key={ingredient.id}>{ingredient.name}</li>
            ))}
          </ol></p>)}
      <img
        src={`data:image/png;base64,${imagePath}`}
        alt={product.name}
        style={{ maxWidth: '300px', maxHeight: '300px' }} />
    </div>
  );
};

export default ProductDetails;
