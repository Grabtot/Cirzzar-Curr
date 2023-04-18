import React from 'react';
import styles from './PizzaItem.module.scss'

const PizzaItem = ({ className, pizza, onEdit, onDelete }) => {
  const { id, name, size, price, ingredients } = pizza;

  return (
    <tr className={className}>
      <td className={styles["table-cell"]}>{name}</td>
      <td className={styles["table-cell"]}>{size}</td>
      <td className={styles["table-cell"]}>${price}</td>
      <td className={styles["table-cell"]}>
        {ingredients.length > 0 ? (
          ingredients.map((ingredient) => ingredient.name).join(', ')
        ) : (
          <em>No ingredients selected</em>
        )}
      </td>
      <td className={`${styles.actions} ${styles["table-cell"]}`}>
        <button className={`${styles["action-button"]} ${styles.edit}`} onClick={() => onEdit(pizza)}>
          Edit
        </button>
        <button className={`${styles["action-button"]} ${styles.delete}`} onClick={() => onDelete(id)}>
          Delete
        </button>
      </td>
    </tr>
  );
};

export default PizzaItem;
