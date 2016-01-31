import { wireList } from '../../utils/dc/wires';

import SchemaList from '../components/SchemaList';
import api from '../api';

var List = ({items}) => (
    <div>
      <h2>Schemas</h2>
      <SchemaList items={items} />
    </div>
);

export default wireList({
  loadItems: api.loadItems
})(List);
