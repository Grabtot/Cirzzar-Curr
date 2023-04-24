import React, { useEffect, useState } from 'react';
import { CircularProgress } from '@mui/material';
import { getPizzaProducts } from '../../api-products/ProductsService';
import PizzaItem from '../PizzaItem/PizzaItem';

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

  if (loading) {
    return <CircularProgress size={40} />
  }

  return (
    <div>
      {pizzas.map(pizza => <PizzaItem key={pizza.id} pizza={pizza} />)}
    </div>
  );
}

export default ProductList;
