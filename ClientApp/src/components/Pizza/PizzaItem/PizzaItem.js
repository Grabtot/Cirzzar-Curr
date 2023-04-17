import React from 'react';

const PizzaItem = ({ pizza }) => {
  const { name, size, price, ingredients } = pizza;

  return (
    <div className="pizza-item">
      <h3>{name}</h3>
      <p>
        Size: <strong>{size}</strong>
      </p>
      <p>
        Price: <strong>${price}</strong>
      </p>
      <p>
        Ingredients:{' '}
        {ingredients.length > 0 ? (
          ingredients.map(ingredient => ingredient.name).join(', ')
        ) : (
          <em>No ingredients selected</em>
        )}
      </p>
    </div>
  );
};

export default PizzaItem;
