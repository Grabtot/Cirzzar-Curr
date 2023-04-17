import React from 'react';
import PizzaItem from '../PizzaItem/PizzaItem';

const PizzaList = ({ pizzas, loading }) => {
  if (loading) {
    return <p>Loading pizzas...</p>;
  }

  return (
    <div>
      {pizzas.length === 0 ? <p>No pizzas</p> : pizzas.map((pizza) => (
        <PizzaItem key={pizza.id} pizza={pizza} />
      ))}
    </div>
  );
};

export default PizzaList;
