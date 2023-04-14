import React, { useState, useEffect } from 'react';
import PizzaList from './PizzaList/PizzaList';
import AddPizza from './AddPizza/AddPizza';
import { getPizzaProducts } from '../api-products/ProductsService';

const Pizza = () => {
  const [pizzas, setPizzas] = useState([]);
  const [loading, setLoading] = useState(true);
  const fetchPizzas = async () => {
    const fetchedPizzas = await getPizzaProducts();
    setPizzas(fetchedPizzas);
    setLoading(false);
  };

  useEffect(() => {
    fetchPizzas();
  }, []);

  return (
    <div>
      <h2>Pizzas</h2>
      <PizzaList pizzas={pizzas} loading={loading} />
      <AddPizza onPizzaAdded={fetchPizzas} />
    </div>
  );
};

export default Pizza;
