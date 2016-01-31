import SettingsList from '../components/SettingsList';

import { wireList } from '../../utils/dc/wires';

import { instancesApi } from '../api';

var List = ({items}) => (
    <div>
      <h2>Settings</h2>
      <SettingsList items={items} />
    </div>
);

export default wireList({
  loadItems: instancesApi.loadItems
})(List);
