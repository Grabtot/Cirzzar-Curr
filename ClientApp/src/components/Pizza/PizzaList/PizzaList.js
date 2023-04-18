import React from 'react';
import PizzaItem from '../PizzaItem/PizzaItem';
import styles from './PizzaList.module.scss'
const PizzaList = ({ pizzas, loading, onEdit, onDelete }) => {
  if (loading) {
    return <p>Loading pizzas...</p>;
  }

  return (
    <table className={styles["pizza-table"]}>
      <thead>
        <tr>
          <th className={styles["table-header"]}>Name</th>
          <th className={styles["table-header"]}>Size</th>
          <th className={styles["table-header"]}>Price</th>
          <th className={styles["table-header"]}>Ingredients</th>
          <th className={styles["table-header"]}>Actions</th>
        </tr>
      </thead>
      <tbody>
        {pizzas.length === 0 ? (
          <tr>
            <td colSpan="5">No pizzas</td>
          </tr>
        ) : (
          pizzas.map((pizza) => <PizzaItem className={styles["table-row"]} key={pizza.id} pizza={pizza} onEdit={onEdit} onDelete={onDelete} />)
        )}
      </tbody>
    </table>
  );
};

export default PizzaList;
