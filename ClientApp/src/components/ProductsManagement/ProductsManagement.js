import React, { useState, useEffect } from 'react';
import ProductList from './ProductList/ProductList';
import AddProduct from './AddProduct/AddProduct';
import { addProduct, deleteProduct, getAllProducts, updateProduct } from '../api-products/ProductsService';

const ProductsManagement = () => {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);
  const fetchProducts = async () => {
    const fetchedProducts = await getAllProducts();
    setProducts(fetchedProducts);
    console.log("Products", fetchedProducts);
    setLoading(false);
  };

  useEffect(() => {
    fetchProducts();
  }, []);

  const onEdit = async (pizza) => {
    await updateProduct(pizza);
    await fetchProducts();
  }

  const onDelete = async (id) => {
    await deleteProduct(id);
    await fetchProducts();
  }

  const onAdd = async (product) => {
    await addProduct(product);
    await fetchProducts();
  }

  return (
    <div>
      <h2>Products</h2>
      <ProductList products={products} loading={loading} onEdit={onEdit} onDelete={onDelete} />
      <AddProduct onAdd={onAdd} />
    </div>
  );
};

export default ProductsManagement;
