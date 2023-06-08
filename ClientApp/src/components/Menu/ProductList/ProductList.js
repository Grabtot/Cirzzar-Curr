import React, { useEffect, useState } from 'react';
import { CircularProgress } from '@mui/material';
import { getPizzaProducts } from '../../api-products/ProductsService';
import PizzaItem from '../PizzaItem/PizzaItem';
import { AddToCart } from '../../api-user/UserService';

const ProductList = () => {
  const [pizzas, setPizzas] = useState([]);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    const fetchPizzas = async () => {
      setPizzas(await getPizzaProducts())
      setLoading(false);
    }
    fetchPizzas();
  }, []);

  const addToCart = (product) => {
    console.log(product);
    AddToCart(product);
  }

  if (loading) {
    return <CircularProgress size={40} />
  }

  return (
    <div>
      {pizzas.map(pizza => <PizzaItem key={pizza.id} pizza={pizza} addToCart={addToCart} />)}
    </div>
  );
}

export default ProductList;
