import React from 'react';

const PizzaItem = ({ pizza }) => {
  const { name, pizzaSize, price, ingredients } = pizza;

  return (
    <div className="pizza-item">
      <h3>{name}</h3>
      <p>
        Size: <strong>{pizzaSize}</strong>
      </p>
      <p>
        Price: <strong>${price}</strong>
      </p>
      <p>
        Ingredients:{' '}
        {ingredients.length > 0 ? (
          ingredients.join(', ')
        ) : (
          <em>No ingredients selected</em>
        )}
      </p>
    </div>
  );
};

export default PizzaItem;
